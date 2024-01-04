using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class WatchlistController : ControllerBase
{
    [HttpPost("add/{movieId}")]
    public IActionResult AddToWatchlist(int movieId)
    {
        return Ok();
    }

    [HttpDelete("remove/{movieId}")]
    public IActionResult RemoveFromWatchlist(int movieId)
    {
        return Ok();
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetUserWatchlist(int userId)
    {
        return Ok();
    }
}
