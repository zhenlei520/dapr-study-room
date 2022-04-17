using Masa.Utils.Development.Dapr.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDaprStarter();
var app = builder.Build();

app.Map("/hello", () => Console.WriteLine("Hello World!"));

app.Run();
