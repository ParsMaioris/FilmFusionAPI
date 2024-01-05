using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GenresController : ControllerBase
{
    [HttpGet("list")]
    public IActionResult ListGenres()
    {
        // TODO: Implement ListGenres
        return Ok();
    }
}
