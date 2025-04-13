using AIDocReader.Client;
using AIDocReader.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IClient, Client>();

var app = builder.Build();




app.Run();



//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
