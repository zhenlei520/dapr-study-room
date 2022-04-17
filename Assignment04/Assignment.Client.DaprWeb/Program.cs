using Masa.Utils.Caller.Core;
using Masa.Utils.Caller.DaprClient;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCaller(callerOptions => callerOptions.UseDapr(daprOption => daprOption.AppId = "assignment-server"));

var app = builder.Build();

app.MapGet("/", () => "Hello Assignment.Client.DaprWeb!");

app.MapGet("/caller", async ([FromServices] ICallerProvider callerProvider) => await callerProvider.GetStringAsync("/Hello1"));
app.MapGet("/caller2", async ([FromServices] ICallerProvider callerProvider) => await callerProvider.PostAsync<object, string>("/Hello2", new()));

app.Run();
