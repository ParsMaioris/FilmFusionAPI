using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class DirectorsController : ControllerBase
{
    [HttpGet("search/{query}")]
    public IActionResult SearchDirectors(string query)
    {
        return Ok();
    }

    [HttpGet("details/{id}")]
    public IActionResult GetDirectorDetails(int id)
    {
        return Ok();
    }
}
