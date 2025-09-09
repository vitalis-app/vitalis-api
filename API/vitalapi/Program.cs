using Microsoft.AspNetCore.Diagnostics;

using Microsoft.EntityFrameworkCore;

using vitalapi.Context;



var builder = WebApplication.CreateBuilder(args);



// Logging no console

builder.Logging.ClearProviders();

builder.Logging.AddConsole();



var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

builder.WebHost.UseUrls($"http://*:{port}");



// Controllers e Swagger

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



// Conexão com o banco

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



//  Middleware de tratamento de erros

app.UseExceptionHandler(errorApp =>

{

    errorApp.Run(async context =>

    {

        var logger = app.Services.GetRequiredService<ILogger<Program>>();

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();



        logger.LogError(exceptionHandlerPathFeature?.Error, " Erro interno em {Path}", exceptionHandlerPathFeature?.Path);



        context.Response.StatusCode = 500;

        context.Response.ContentType = "application/json";



        await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new

        {

            StatusCode = 500,

            Message = "Ocorreu um erro interno no servidor."

        }));

    });

});



// Swagger sempre ativo

app.UseSwagger();

app.UseSwaggerUI();



// Health check

app.MapGet("/healthz", () => Results.Ok("Healthy"));



// Middleware de autorização

app.UseAuthorization();



// Mapeamento dos controllers

app.MapControllers();



// Iniciar app

app.Run();

