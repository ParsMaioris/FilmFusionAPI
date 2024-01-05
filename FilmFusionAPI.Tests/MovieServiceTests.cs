using Moq;

namespace FilmFusionAPI.Tests;

[TestClass]
public class MovieServiceTests
{
    private static readonly List<Movie> SampleMovies = CreateSampleMovies();

    [TestMethod]
    [DynamicData(nameof(GetFilterTestCases), DynamicDataSourceType.Method)]
    public async Task FilterMoviesByGenreAndMinimumPopularity_ReturnsExpectedResults(int genre, double minPopularity, int expectedCount)
    {
        // Arrange
        var movieGenre = (MovieGenre)genre;
        var mockMoviesClient = new Mock<IMoviesClient>();
        mockMoviesClient.Setup(client => client.GetMoviesAsync(It.IsAny<int>()))
            .ReturnsAsync(new MovieSearchResult { Results = SampleMovies });

        var mockDataValidator = new Mock<IDataValidator>();
        mockDataValidator.Setup(validator => 
            validator.ValidateNotEmpty(It.IsAny<IEnumerable<Movie>>(), It.IsAny<string>()));
        mockDataValidator.Setup(validator => 
            validator.ValidateSufficientItems(It.IsAny<IEnumerable<Movie>>(), It.IsAny<int>(), It.IsAny<string>()));

        var movieService = new MovieService(mockMoviesClient.Object, mockDataValidator.Object);


        // Act
        var filteredMovies = await movieService.FilterMoviesAsync(movieGenre, minPopularity);

        // Assert
        Assert.AreEqual(expectedCount, filteredMovies.Count());
    }

    public static IEnumerable<object[]> GetFilterTestCases()
    {
        yield return new object[] { (int)MovieGenre.Action, 7.5, 5 };
        yield return new object[] { (int)MovieGenre.Drama, 6.0, 4 };
        yield return new object[] { (int)MovieGenre.Comedy, 7.0, 1 };
    }

    public static List<Movie> CreateSampleMovies()
    {
        return new List<Movie>
        {
            new MovieBuilder().WithGenres(new[] { MovieGenre.Action }).WithPopularity(8.0).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Drama }).WithPopularity(6.5).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Comedy }).WithPopularity(7.0).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Action, MovieGenre.Adventure }).WithPopularity(9.0).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Horror }).WithPopularity(5.0).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Action }).WithPopularity(3.5).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Drama }).WithPopularity(8.5).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Comedy }).WithPopularity(6.0).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Action, MovieGenre.Romance }).WithPopularity(9.5).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Romance }).WithPopularity(4.5).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Action }).WithPopularity(7.5).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Thriller }).WithPopularity(8.2).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Comedy }).WithPopularity(6.3).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Fantasy }).WithPopularity(7.8).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Action, MovieGenre.Fantasy }).WithPopularity(5.5).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Mystery }).WithPopularity(4.0).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Action }).WithPopularity(8.1).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Drama, MovieGenre.Romance }).WithPopularity(7.9).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Drama }).WithPopularity(6.8).Build(),
            new MovieBuilder().WithGenres(new[] { MovieGenre.Horror, MovieGenre.Thriller }).WithPopularity(7.2).Build()
        };
    }
}

public class MovieBuilder
{
    private readonly Movie _movie = new Movie();

    public MovieBuilder WithGenres(IEnumerable<MovieGenre> genres)
    {
        _movie.GenreIds = genres.Select(g => (int)g).ToList();
        return this;
    }

    public MovieBuilder WithPopularity(double popularity)
    {
        _movie.Popularity = popularity;
        return this;
    }

    public Movie Build()
    {
        return _movie;
    }
}