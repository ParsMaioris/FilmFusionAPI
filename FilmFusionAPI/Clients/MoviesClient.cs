using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

// Response and request models (these should be defined according to your API's contract)
public class MovieSearchResult { /* ... */ }
public class MovieDetails { /* ... */ }
public class PopularMovies { /* ... */ }
public class UpcomingMovies { /* ... */ }
public class MoviesByGenre { /* ... */ }

public class MoviesClient
{
    private readonly HttpClientWrapper _httpClientWrapper;

    public MoviesClient(HttpClientWrapper httpClientWrapper)
    {
        _httpClientWrapper = httpClientWrapper ?? throw new ArgumentNullException(nameof(httpClientWrapper));
    }

    public async Task<List<MovieSearchResult>> SearchMoviesAsync(string query)
    {
        // Adjust the URL according to your API's endpoint structure
        return await _httpClientWrapper.GetAsync<List<MovieSearchResult>>($"movies/search/{query}");
    }

    public async Task<MovieDetails> GetMovieDetailsAsync(int id)
    {
        return await _httpClientWrapper.GetAsync<MovieDetails>($"movies/details/{id}");
    }

    public async Task<List<PopularMovies>> GetPopularMoviesAsync()
    {
        return await _httpClientWrapper.GetAsync<List<PopularMovies>>("movies/popular");
    }

    public async Task<List<UpcomingMovies>> GetUpcomingMoviesAsync()
    {
        return await _httpClientWrapper.GetAsync<List<UpcomingMovies>>("movies/upcoming");
    }

    public async Task<List<MoviesByGenre>> GetMoviesByGenreAsync(int genreId)
    {
        return await _httpClientWrapper.GetAsync<List<MoviesByGenre>>($"movies/genre/{genreId}");
    }
}
