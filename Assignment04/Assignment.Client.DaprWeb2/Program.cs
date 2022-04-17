using Masa.Utils.Caller.Core;
using Masa.Utils.Caller.DaprClient;
using Masa.Utils.Development.Dapr.AspNetCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
    builder.Services.AddDaprStarter();

builder.Services.AddCaller(callerOptions => callerOptions.UseDapr(daprOption => daprOption.AppId = "assignment-server"));

var app = builder.Build();

app.MapGet("/", () => "Hello Assignment.Client.DaprWeb!");

app.MapGet("/caller", async ([FromServices] ICallerProvider callerProvider) => await callerProvider.GetStringAsync("/Hello1"));
app.MapGet("/caller2", async ([FromServices] ICallerProvider callerProvider) => await callerProvider.PostAsync<object, string>("/Hello2", new()));

app.Run();
