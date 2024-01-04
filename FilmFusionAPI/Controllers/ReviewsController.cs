using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ReviewsController : ControllerBase
{
    [HttpGet("{movieId}")]
    public IActionResult GetReviews(int movieId)
    {
        return Ok();
    }
}
