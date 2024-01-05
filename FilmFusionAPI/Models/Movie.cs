using Newtonsoft.Json;

public class MovieSearchResult
{
    public List<Movie> Results { get; set; }
}

public class Movie
{
    public int Id { get; set; }
    public bool Adult { get; set; }
    public string BackdropPath { get; set; }

    [JsonProperty("genre_ids")]
    public List<int> GenreIds { get; set; }
    public string OriginalLanguage { get; set; }
    public string OriginalTitle { get; set; }
    public string Overview { get; set; }
    public double Popularity { get; set; }
    public string PosterPath { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Title { get; set; }
    public bool Video { get; set; }
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }
}

public enum MovieGenre
{
    Action = 28,
    Adventure = 12,
    Animation = 16,
    Comedy = 35,
    Crime = 80,
    Documentary = 99,
    Drama = 18,
    Family = 10751,
    Fantasy = 14,
    History = 36,
    Horror = 27,
    Music = 10402,
    Mystery = 9648,
    Romance = 10749,
    ScienceFiction = 878,
    TVMovie = 10770,
    Thriller = 53,
    War = 10752,
    Western = 37
}
