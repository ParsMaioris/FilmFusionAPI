public interface IMoviesClient
{
    Task<MovieSearchResult> GetMoviesAsync(int page = 20);
    Task<MovieSearchResult> SearchMoviesAsync(string query);
    Task<MovieSearchResult> GetMovieDetailsAsync(int id);
}