public class MovieService
{
    private readonly IMoviesClient _moviesClient;

    public MovieService(IMoviesClient moviesClient)
    {
        _moviesClient = moviesClient ?? throw new ArgumentNullException(nameof(moviesClient));
    }

    public async Task<IEnumerable<Movie>> FilterMoviesAsync(MovieGenre? genre, double? minimumPopularity)
    {
        var allMovies = await _moviesClient.GetMoviesAsync();
        var result = allMovies.Results;

        if (genre.HasValue)
        {
            result = result.Where(movie => MatchesGenre(movie, genre.Value)).ToList();
        }

        if (minimumPopularity.HasValue)
        {
            result = result.Where(movie => IsPopularEnough(movie, minimumPopularity.Value)).ToList();
        }

        return result;
    }

    private bool MatchesGenre(Movie movie, MovieGenre genre)
    {
        return movie.GenreIds.Contains((int)genre);
    }

    private bool IsPopularEnough(Movie movie, double minimumPopularity)
    {
        return movie.Popularity >= minimumPopularity;
    }
}
