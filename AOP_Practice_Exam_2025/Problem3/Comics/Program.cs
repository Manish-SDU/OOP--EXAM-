using System.Globalization;
using Comics.Models;
using CsvHelper;

var comics = new List<Comic>();

// Read CSV file
using (var reader = new StreamReader("data/comics.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    comics = csv.GetRecords<Comic>().ToList();
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
