public class MoviesClient
{
    private readonly IHttpClientWrapper _httpClientWrapper;

    public MoviesClient(IHttpClientWrapper httpClientWrapper)
    {
        _httpClientWrapper = httpClientWrapper ?? throw new ArgumentNullException(nameof(httpClientWrapper));
    }

    public async Task<MovieSearchResult> SearchMoviesAsync(string query)
    {
        return await _httpClientWrapper.GetAsync<MovieSearchResult>($"search/movie?query={Uri.EscapeDataString(query)}");
    }

    public async Task<MovieDetails> GetMovieDetailsAsync(int id)
    {
        return await _httpClientWrapper.GetAsync<MovieDetails>($"movie/{id}");
    }
}
