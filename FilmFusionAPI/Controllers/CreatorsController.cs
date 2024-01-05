using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CreatorsController : ControllerBase
{
    [HttpGet("search/{query}")]
    public IActionResult SearchActors(string query)
    {
        // TODO: Implement SearchActors
        return Ok();
    }

    [HttpGet("details/{id}")]
    public IActionResult GetActorDetails(int id)
    {
        // TODO: Implement GetActorDetails
        return Ok();
    }
}
