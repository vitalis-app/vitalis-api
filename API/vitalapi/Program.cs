// ===================================================================
// ARQUIVO: Program.cs
// DESCRIÇÃO: Configuração completa da API com Entity Framework,
//            Swagger, Health Check e Autenticação JWT.
// ===================================================================

// --- 1. Usings (Importações) ---
// Todos os 'usings' devem estar no topo do arquivo.
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using vitalapi.Context;

var builder = WebApplication.CreateBuilder(args);

// --- 2. Configuração da Porta para o Railway ---
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");


// --- 3. Registro de Serviços no Container de Injeção de Dependência ---

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuração do Swagger para incluir o botão "Authorize"
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Vitalis API", Version = "v1" });

    // Define o esquema de segurança Bearer (JWT)
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor, insira 'Bearer ' seguido do seu token JWT",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    // Aplica o requisito de segurança a todas as operações
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


// Configuração do Banco de Dados
string connectionString;
var dbHost = Environment.GetEnvironmentVariable("MYSQLHOST");

if (string.IsNullOrEmpty(dbHost))
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
else
{
    var dbPassword = Environment.GetEnvironmentVariable("MYSQLPASSWORD");
    var dbUser = Environment.GetEnvironmentVariable("MYSQLUSER");
    var dbPort = Environment.GetEnvironmentVariable("MYSQLPORT");
    var dbName = Environment.GetEnvironmentVariable("MYSQLDATABASE");
    connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};Uid={dbUser};Pwd={dbPassword};";
}

var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
builder.Services.AddDbContext<vitalcontext>(options =>
    options.UseMySql(connectionString, serverVersion)
);


// --- 4. Configuração da Autenticação JWT ---
// Lê as configurações do JWT do appsettings.json
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

if (jwtKey != null)
{
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });
}


// --- 5. Construção do App ---
var app = builder.Build();


// --- 6. Configuração do Pipeline de Requisições HTTP ---

// Swagger apenas em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoint para o Health Check do Railway
app.MapGet("/healthz", () => Results.Ok("Healthy"));

// Adiciona os middlewares de Autenticação e Autorização
// IMPORTANTE: A ordem é crucial. Authentication DEVE vir antes de Authorization.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


// --- 7. Execução do App ---
app.Run();
