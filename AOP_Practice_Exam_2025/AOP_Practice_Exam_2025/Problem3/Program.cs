using CsvHelper;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        var comics = LoadComics("data/comics.csv").ToList();

        // Query 1: Comics before 2000
        var oldComics = comics.Where(c => c.Year < 2000)
                            .OrderBy(c => c.Year);
        Console.WriteLine("Comics before 2000:");
        foreach (var comic in oldComics)
            Console.WriteLine($"{comic.Title} ({comic.Year})");

        // Query 2: Comics per author
        var authorStats = comics.GroupBy(c => c.Author)
                              .Select(g => new { Author = g.Key, Count = g.Count() })
                              .OrderByDescending(x => x.Count);
        Console.WriteLine("\nComics per author:");
        foreach (var stat in authorStats)
            Console.WriteLine($"{stat.Author}: {stat.Count}");

        // Query 3: Most active author per year
        var mostActiveByYear = comics.GroupBy(c => c.Year)
                                   .Select(g => new {
                                       Year = g.Key,
                                       Author = g.GroupBy(c => c.Author)
                                                .OrderByDescending(ag => ag.Count())
                                                .First().Key
                                   })
                                   .OrderBy(x => x.Year);
        Console.WriteLine("\nMost active author by year:");
        foreach (var item in mostActiveByYear)
            Console.WriteLine($"{item.Year}: {item.Author}");
    }

    private static IEnumerable<Comic> LoadComics(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<Comic>().ToList();
    }
}
