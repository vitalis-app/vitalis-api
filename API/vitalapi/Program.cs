var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Ol�, Mundo! A API est� no ar!");

app.Run();