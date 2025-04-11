using AIDocReader.Client;
using AIDocReader.Service;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IClient, Client>();

var app = builder.Build();

app.MapGet("/", () => Results.Ok("API is running ✅"));

app.MapPost("/getword", async (
    [FromBody] Keyword request,
    [FromServices] IService service) =>
{
    var token = new CancellationToken();
    try
    {
        var found = await service.CheckIfWordInDocument(request.Word, token);
        var response = new
        {
            Word = request.Word,
            Found = found
        };

        return Results.Json(response);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error while checking the document: {ex.Message}");
    }
});



app.Run();

public class Keyword
{
    public string Word { get; set; }
}

//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
