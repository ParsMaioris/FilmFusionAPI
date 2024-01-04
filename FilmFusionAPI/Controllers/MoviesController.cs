using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    [HttpGet("search/{query}")]
    public IActionResult SearchMovies(string query)
    {
        return Ok();
    }

    [HttpGet("details/{id}")]
    public IActionResult GetMovieDetails(int id)
    {
        return Ok();
    }

    [HttpGet("popular")]
    public IActionResult GetPopularMovies()
    {
        return Ok();
    }

    [HttpGet("upcoming")]
    public IActionResult GetUpcomingMovies()
    {
        return Ok();
    }

    [HttpGet("genre/{genreId}")]
    public IActionResult GetMoviesByGenre(int genreId)
    {
        return Ok();
    }
}
