using AIDocReader.Client;
using AIDocReader.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);


builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IClient, Client>();

builder.Services.AddControllers();


var app = builder.Build();
app.MapControllers();


app.Run();

