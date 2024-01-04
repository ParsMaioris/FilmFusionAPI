using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class RatingsController : ControllerBase
{
    [HttpGet("{movieId}")]
    public IActionResult GetRatings(int movieId)
    {
        return Ok();
    }

    [HttpGet("top")]
    public IActionResult GetTopRatedMovies()
    {
        return Ok();
    }
}
