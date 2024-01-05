public class MovieStatistics
{
    public double AveragePopularity(IEnumerable<Movie> movies)
    {
        ValidateNotEmpty(movies, "Calculate average popularity");
        return movies.Average(movie => movie.Popularity);
    }

    public double TotalPopularity(IEnumerable<Movie> movies)
    {
        ValidateNotEmpty(movies, "Calculate total popularity");
        return movies.Sum(movie => movie.Popularity);
    }

    public Movie HighestRatedMovie(IEnumerable<Movie> movies)
    {
        return GetNthHighestRatedMovie(movies, 1);
    }

    public Movie SecondHighestRatedMovie(IEnumerable<Movie> movies)
    {
        return GetNthHighestRatedMovie(movies, 2);
    }

    private Movie GetNthHighestRatedMovie(IEnumerable<Movie> movies, int n)
    {
        ValidateSufficientMovies(movies, n, $"Determine {n} highest rated movie");
        return movies.OrderByDescending(movie => movie.Popularity).Skip(n - 1).First();
    }

    private void ValidateNotEmpty(IEnumerable<Movie> movies, string operation)
    {
        if (!movies.Any())
        {
            throw new InvalidOperationException($"Cannot {operation} from an empty list.");
        }
    }

    private void ValidateSufficientMovies(IEnumerable<Movie> movies, int requiredCount, string operation)
    {
        if (movies.Count() < requiredCount)
        {
            throw new InvalidOperationException($"Cannot {operation} from a list with less than {requiredCount} elements.");
        }
    }
}