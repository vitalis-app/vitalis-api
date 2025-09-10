using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Configuração da porta para funcionar com o Railway e localmente
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

// =================== INÍCIO DA ALTERAÇÃO ===================

// 1. Declara a variável que vai guardar a string de conexão final
string connectionString;

// 2. Verifica se o ambiente é de Produção (como no Railway)
if (builder.Environment.IsProduction())
{
    // Usa a variável de ambiente DATABASE_URL fornecida pelo Railway
    connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
}
else
{
    // Se não for produção (é Desenvolvimento), pega a string do appsettings.json
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}

// 3. Configura o DbContext usando a connection string correta
builder.Services.AddDbContext<VitalContext>(options =>
{
    // Usamos AutoDetect para que a versão do servidor MySQL seja detectada automaticamente.
    // Isso funciona bem tanto para o MySQL local quanto para o do Railway.
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// =================== FIM DA ALTERAÇÃO ===================


// Adiciona os serviços da sua aplicação
builder.Services.AddScoped<AgendamentoService>();
builder.Services.AddScoped<AssinaturaService>();
builder.Services.AddScoped<DisponibilidadeService>();
builder.Services.AddScoped<EspecialistaService>();
builder.Services.AddScoped<PlanoService>();
builder.Services.AddScoped<RegistroEmocionalService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<UsuarioProgressoService>();
builder.Services.AddScoped<UsuarioPlantaService>();
builder.Services.AddScoped<UsuarioService>();

// Configuração da autenticação JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/healthz", () => Results.Ok("Healthy"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();