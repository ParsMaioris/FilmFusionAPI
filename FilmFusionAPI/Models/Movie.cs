public class MovieSearchResult
{
    public List<Movie> Results { get; set; }
}

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
}

public class MovieDetails
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
}

