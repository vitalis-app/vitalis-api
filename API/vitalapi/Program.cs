using Microsoft.EntityFrameworkCore;
using vitalapi.Context;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

builder.Services.AddDbContext<VitalContext>(options =>
    options.UseMySql(connectionString, serverVersion)
);

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();



app.MapGet("/healthz", () => Results.Ok("Healthy"));

app.UseAuthorization();
app.MapControllers();

app.Run();