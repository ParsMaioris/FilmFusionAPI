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

    [HttpGet("averagePopularity")]
    public async Task<IActionResult> GetAveragePopularity()
    {
        var averagePopularity = await _movieService.AveragePopularity();
        return Ok(averagePopularity);
    }

    [HttpGet("totalPopularity")]
    public async Task<IActionResult> GetTotalPopularity()
    {
        var totalPopularity = await _movieService.TotalPopularity();
        return Ok(totalPopularity);
    }

    [HttpGet("highestRatedMovie")]
    public async Task<IActionResult> GetHighestRatedMovie()
    {
        var highestRatedMovie = await _movieService.HighestRatedMovie();
        return Ok(highestRatedMovie);
    }

    [HttpGet("secondHighestRatedMovie")]
    public async Task<IActionResult> GetSecondHighestRatedMovie()
    {
        var secondHighestRatedMovie = await _movieService.SecondHighestRatedMovie();
        return Ok(secondHighestRatedMovie);
    }
}