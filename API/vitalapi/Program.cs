using Microsoft.EntityFrameworkCore;
using vitalapi.Context; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
string connectionString;

if (string.IsNullOrEmpty(connectionUrl))
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
else
{
    connectionString = connectionUrl;
}

builder.Services.AddDbContext<vitalcontext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();