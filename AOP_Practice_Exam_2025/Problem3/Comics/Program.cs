using System.Globalization;
using Comics.Models;
using CsvHelper;
using CsvHelper.Configuration;

var comics = new List<Comic>();

try
{
    // Read CSV file
    using (var reader = new StreamReader("data/comics.csv"))
    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        HeaderValidated = null, // Disable header validation
        MissingFieldFound = null // Disable missing field errors
    }))
    {
        // Validate headers
        csv.Read();
        csv.ReadHeader();
        var headers = csv.HeaderRecord;
        var requiredHeaders = new[] { "Title", "Author", "Year" };
        
        foreach (var header in requiredHeaders)
        {
            if (!headers.Contains(header))
            {
                throw new Exception($"Missing required header: {header}");
            }
        }

        comics = csv.GetRecords<Comic>().ToList();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error reading CSV file: {ex.Message}");
    return;
}

// Query 1: Comics before 2000
Console.WriteLine("Comics released before 2000:");
var oldComics = comics.Where(c => c.Year < 2000)
                     .OrderBy(c => c.Year);

foreach (var comic in oldComics)
{
    Console.WriteLine($"{comic.Year}: {comic.Title} by {comic.Author}");
}

// Query 2: Comics per author
Console.WriteLine("\nNumber of comics by each author:");
var comicsPerAuthor = comics.GroupBy(c => c.Author)
                           .Select(g => new { Author = g.Key, Count = g.Count() })
                           .OrderByDescending(x => x.Count);

foreach (var author in comicsPerAuthor)
{
    Console.WriteLine($"{author.Author}: {author.Count} comics");
}

// Query 3: Most active author per year
Console.WriteLine("\nMost active author per year:");
var mostActiveByYear = comics.GroupBy(c => c.Year)
                            .Select(g => new {
                                Year = g.Key,
                                Author = g.GroupBy(c => c.Author)
                                        .OrderByDescending(ag => ag.Count())
                                        .First().Key,
                                Count = g.GroupBy(c => c.Author)
                                        .OrderByDescending(ag => ag.Count())
                                        .First().Count()
                            })
                            .OrderBy(x => x.Year);

foreach (var year in mostActiveByYear)
{
    Console.WriteLine($"{year.Year}: {year.Author} ({year.Count} comics)");
}
