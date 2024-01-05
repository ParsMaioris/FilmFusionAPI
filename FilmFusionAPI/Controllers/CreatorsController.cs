using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CreatorsController : ControllerBase
{
    [HttpGet("search/{query}")]
    public IActionResult SearchActors(string query)
    {
        return Ok();
    }

    [HttpGet("details/{id}")]
    public IActionResult GetActorDetails(int id)
    {
        return Ok();
    }
}
