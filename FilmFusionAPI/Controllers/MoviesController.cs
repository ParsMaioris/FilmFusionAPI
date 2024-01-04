using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MoviesClient _moviesClient;

    public MoviesController(MoviesClient moviesClient)
    {
        _moviesClient = moviesClient ?? throw new ArgumentNullException(nameof(moviesClient));
    }

    [HttpGet("search/{query}")]
    public async Task<IActionResult> SearchMovies(string query)
    {
        var results = await _moviesClient.SearchMoviesAsync(query);
        return Ok(results);
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetMovieDetails(int id)
    {
        var movieDetails = await _moviesClient.GetMovieDetailsAsync(id);
        return Ok(movieDetails);
    }
}
