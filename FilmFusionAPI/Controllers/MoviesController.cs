using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MovieService _movieService;

    public MoviesController(MovieService movieService)
    {
        _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
    }

    [HttpGet("filteredMovies")]
    public async Task<IActionResult> GetFilteredMovies([FromQuery] MovieGenre? genre, [FromQuery] double? popularity)
    {
        var filteredMovies = await _movieService.FilterMoviesAsync(genre, popularity);
        return Ok(filteredMovies);
    }
}