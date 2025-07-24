using Microsoft.EntityFrameworkCore;
using vitalapi.Context;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// --- IN�CIO DO NOVO BLOCO DE C�DIGO DE CONFIGURA��O DO BANCO DE DADOS ---

string connectionString;

// Verifica se est� no ambiente do Railway (procurando pelo host do MySQL injetado)
var dbHost = Environment.GetEnvironmentVariable("MYSQLHOST");

if (string.IsNullOrEmpty(dbHost))
{
    // Se n�o encontrar, assume que est� no ambiente LOCAL e pega a string do appsettings.json
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
else
{
    // Se encontrar, est� no ambiente RAILWAY e constr�i a string de conex�o
    // a partir das vari�veis de ambiente individuais que o Railway fornece.
    var dbPassword = Environment.GetEnvironmentVariable("MYSQLPASSWORD");
    var dbUser = Environment.GetEnvironmentVariable("MYSQLUSER");
    var dbPort = Environment.GetEnvironmentVariable("MYSQLPORT");
    var dbName = Environment.GetEnvironmentVariable("MYSQLDATABASE");

    connectionString = $"Server={dbHost};Port={dbPort};Database={dbName};Uid={dbUser};Pwd={dbPassword};";
}

// Especifica a vers�o do MySQL manualmente para evitar o AutoDetect
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));

// Adiciona o DbContext ao servi�o, agora com a vers�o expl�cita
builder.Services.AddDbContext<vitalcontext>(options =>
    options.UseMySql(connectionString, serverVersion)
);

// --- FIM DO NOVO BLOCO ---


var app = builder.Build();

// Configura o pipeline de requisi��es HTTP.
// A forma correta � manter o Swagger apenas em ambiente de desenvolvimento.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();