
using AIDocReader.Client;
using AIDocReader.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);


builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IClient, Client>();

//builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapPost("/getword", async (Keyword request, IService service, CancellationToken token) =>
{
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


app.UseHttpsRedirection();

app.Run();

public class Keyword
{
    public string Word { get; set; }
}
