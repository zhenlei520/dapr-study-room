using Masa.Utils.Development.Dapr.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
    builder.Services.AddDaprStarter(opt =>
    {
        opt.AppId = "assignment-server";
        opt.AppIdSuffix = String.Empty;
        opt.DaprHttpPort = 8090;
        opt.DaprGrpcPort = 8091;
    }); //不需要dapr管理SideCar可注释此行

var app = builder.Build();

app.MapPost("/", () => Console.WriteLine("Hello!"));

app.MapGet("/Hello1", () => "Hello World1!");

app.MapPost("/Hello2", () => "Hello World2!");

app.Run();
