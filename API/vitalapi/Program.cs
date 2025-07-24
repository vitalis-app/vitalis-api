using Microsoft.EntityFrameworkCore;
using vitalapi.Context;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// --- INÍCIO DO NOVO BLOCO DE CÓDIGO DE CONFIGURAÇÃO DO BANCO DE DADOS ---

string connectionString;

// Verifica se está no ambiente do Railway (procurando pelo host do MySQL injetado)
var dbHost = Environment.GetEnvironmentVariable("MYSQLHOST");

if (string.IsNullOrEmpty(dbHost))
{
    // Se não encontrar, assume que está no ambiente LOCAL e pega a string do appsettings.json
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
else
{
    // Se encontrar, está no ambiente RAILWAY e constrói a string de conexão
    // a partir das variáveis de ambiente individuais que o Railway fornece.
    var dbPassword = Environment.GetEnvironmentVariable("MYSQLPASSWORD");
    var dbUser = Environment.GetEnvironmentVariable("MYSQLUSER");
    var dbPort = Environment.GetEnvironmentVariable("MYSQLPORT");
    var dbName = Environment.GetEnvironmentVariable("MYSQLDATABASE");

    connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};Uid={dbUser};Pwd={dbPassword};";
}

// Especifica a versão do MySQL manualmente para evitar o AutoDetect
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));

// Adiciona o DbContext ao serviço, agora com a versão explícita
builder.Services.AddDbContext<vitalcontext>(options =>
    options.UseMySql(connectionString, serverVersion)
);

// --- FIM DO NOVO BLOCO ---


var app = builder.Build();

// Configura o pipeline de requisições HTTP.
// A forma correta é manter o Swagger apenas em ambiente de desenvolvimento.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();