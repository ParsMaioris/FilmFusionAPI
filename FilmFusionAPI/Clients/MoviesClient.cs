public class MoviesClient : IMoviesClient
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

    public async Task<MovieSearchResult> GetMovieDetailsAsync(int id)
    {
        return await _httpClientWrapper.GetAsync<MovieSearchResult>($"movie/{id}");
    }

    public async Task<MovieSearchResult> GetMoviesAsync(int pageNumber)
    {
        return await _httpClientWrapper.GetAsync<MovieSearchResult>($"discover/movie?page={pageNumber}");
    }
}
