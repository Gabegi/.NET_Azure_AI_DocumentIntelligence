using AIDocReader.Controller;
using AIDocReader.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class WordController : ControllerBase
{
    private readonly IService _service;

    public WordController(IService service)
    {
        _service = service;
    }

    [HttpGet("/")]
    public IActionResult GetRoot()
    {
        return Ok("API is running ✅");
    }

    [HttpPost("getword")]
    public async Task<IActionResult> GetWord([FromBody] WordRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var found = await _service.CheckIfWordInDocument(request.KeyWord, cancellationToken);
            var response = new WordResponse
            {
                KeyWord = request.KeyWord,
                Found = found
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            return Problem($"Error while checking the document: {ex.Message}");
        }
    }
}
