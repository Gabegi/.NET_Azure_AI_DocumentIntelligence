
using AIDocReader.Client;
using AIDocReader.Service;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);


builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IClient, Client>();

builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/", () => Results.Ok("API is running ✅"));

app.MapPost("/getword", async(
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
