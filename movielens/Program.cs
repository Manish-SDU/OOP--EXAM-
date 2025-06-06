using CsvHelper;
using System.Globalization;
using System.Linq;

var movies = new List<Movie>();
var ratings = new List<Rating>();

// Read movies.csv
using (var reader = new StreamReader("movies.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    movies = csv.GetRecords<Movie>().ToList();
}

// Read ratings.csv
using (var reader = new StreamReader("ratings.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    ratings = csv.GetRecords<Rating>().ToList();
}

// Merge movies and ratings
var movieRatings = from m in movies
                  join r in ratings on m.MovieId equals r.MovieId
                  select new { Movie = m, Rating = r };

// Calculate top 100 movies
var top100Movies = movieRatings
    .GroupBy(mr => mr.Movie)
    .Select(g => new
    {
        Movie = g.Key,
        AverageRating = g.Average(mr => mr.Rating.UserRating),
        RatingCount = g.Count()
    })
    .Where(m => m.RatingCount >= 100) // Filter movies with at least 100 ratings
    .OrderByDescending(m => m.AverageRating)
    .Take(100)
    .ToList();

// Calculate genre statistics
var allGenres = top100Movies
    .SelectMany(m => m.Movie.GenresList)
    .GroupBy(g => g)
    .Select(g => new
    {
        Genre = g.Key,
        Percentage = (double)g.Count() / top100Movies.Count * 100
    })
    .OrderByDescending(g => g.Percentage)
    .ToList();

// Print results
Console.WriteLine("Top 100 Movies:");
foreach (var movie in top100Movies.Take(10)) // Show first 10 as example
{
    Console.WriteLine($"{movie.Movie.Title}: {movie.AverageRating:F2} ({movie.RatingCount} ratings)");
}

Console.WriteLine("\nGenre Distribution:");
foreach (var genre in allGenres)
{
    Console.WriteLine($"{genre.Genre}: {genre.Percentage:F2}%");
}
