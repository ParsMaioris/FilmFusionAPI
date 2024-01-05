public class MovieService
{
    private readonly IMoviesClient _moviesClient;
    private readonly IDataValidator _validator;

    public MovieService(IMoviesClient moviesClient, IDataValidator validator)
    {
        _moviesClient = moviesClient ?? throw new ArgumentNullException(nameof(moviesClient));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<IEnumerable<Movie>> FilterMoviesAsync(MovieGenre? genre, double? minimumPopularity)
    {
        var movies = await GetAllMoviesAsync("Filter Movies by Genre and Minimum Popularity");
        return movies.Where(movie => MatchesCriteria(movie, genre, minimumPopularity));
    }

    public async Task<double> AveragePopularity()
    {
        var movies = await GetAllMoviesAsync("Calculate average popularity");
        return movies.Average(movie => movie.Popularity);
    }

    public async Task<double> TotalPopularity()
    {
        var movies = await GetAllMoviesAsync("Calculate total popularity");
        return movies.Sum(movie => movie.Popularity);
    }

    public async Task<Movie> HighestRatedMovie() => await GetNthHighestRatedMovie(1);

    public async Task<Movie> SecondHighestRatedMovie() => await GetNthHighestRatedMovie(2);

    private async Task<Movie> GetNthHighestRatedMovie(int n)
    {
        var movies = await GetAllMoviesAsync($"Determine {n} highest rated movie");
        _validator.ValidateSufficientItems(movies, n, $"Determine {n} highest rated movie");
        return movies.OrderByDescending(movie => movie.Popularity).Skip(n - 1).First();
    }

    private async Task<IEnumerable<Movie>> GetAllMoviesAsync(string operation)
    {
        var allMovies = await _moviesClient.GetMoviesAsync();
        _validator.ValidateNotEmpty(allMovies.Results, operation);
        return allMovies.Results;
    }

    private bool MatchesCriteria(Movie movie, MovieGenre? genre, double? minimumPopularity)
    {
        if (genre.HasValue && !MatchesGenre(movie, genre.Value))
        {
            return false;
        }

        if (minimumPopularity.HasValue && !IsPopularEnough(movie, minimumPopularity.Value))
        {
            return false;
        }

        return true;
    }

    private bool MatchesGenre(Movie movie, MovieGenre genre) => movie.GenreIds.Contains((int)genre);

    private bool IsPopularEnough(Movie movie, double minimumPopularity) => movie.Popularity >= minimumPopularity;
}