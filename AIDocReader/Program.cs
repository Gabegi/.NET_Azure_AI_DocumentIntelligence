
var builder = WebApplication.CreateBuilder(args);
var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
var app = builder.Build();

app.MapPost("/getword", (Keyword request) =>
{
    var response = new { Keyword = $"Received: {request.Word}" };
    return Results.Json(response);
});

app.UseHttpsRedirection();

app.Run();

public class Keyword
{
    public string Word { get; set; }
}
