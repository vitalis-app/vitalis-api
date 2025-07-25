// ===================================================================
// ARQUIVO: Program.cs
// DESCRI��O: Configura��o completa da API com Entity Framework,
//            Swagger, Health Check e Autentica��o JWT.
// ===================================================================

// --- 1. Usings (Importa��es) ---
// Todos os 'usings' devem estar no topo do arquivo.
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using vitalapi.Context;

var builder = WebApplication.CreateBuilder(args);

// --- 2. Configura��o da Porta para o Railway ---
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");


// --- 3. Registro de Servi�os no Container de Inje��o de Depend�ncia ---

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configura��o do Swagger para incluir o bot�o "Authorize"
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Vitalis API", Version = "v1" });

    // Define o esquema de seguran�a Bearer (JWT)
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor, insira 'Bearer ' seguido do seu token JWT",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    // Aplica o requisito de seguran�a a todas as opera��es
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


// Configura��o do Banco de Dados
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


// --- 4. Configura��o da Autentica��o JWT ---
// L� as configura��es do JWT do appsettings.json
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


// --- 5. Constru��o do App ---
var app = builder.Build();


// --- 6. Configura��o do Pipeline de Requisi��es HTTP ---

// Swagger apenas em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoint para o Health Check do Railway
app.MapGet("/healthz", () => Results.Ok("Healthy"));

// Adiciona os middlewares de Autentica��o e Autoriza��o
// IMPORTANTE: A ordem � crucial. Authentication DEVE vir antes de Authorization.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


// --- 7. Execu��o do App ---
app.Run();
