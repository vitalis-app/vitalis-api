using Microsoft.EntityFrameworkCore;
using vitalapi.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// --- BLOCO DE BANCO DE DADOS TEMPORARIAMENTE DESATIVADO ---
/*
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
*/
// --- FIM DO BLOCO DESATIVADO ---


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();