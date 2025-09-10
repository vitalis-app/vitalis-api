using Microsoft.EntityFrameworkCore;
using vitalapi.Context;
using vitalapi.Services;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
builder.Services.AddDbContext<VitalContext>(options =>
    options.UseMySql(connectionString, serverVersion)
);

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