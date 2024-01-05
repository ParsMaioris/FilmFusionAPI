public interface IMoviesClient
{
    Task<MovieSearchResult> GetMoviesAsync(int page = 20);
}