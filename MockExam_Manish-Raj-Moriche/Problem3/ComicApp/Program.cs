using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

public class Program
{
    public static void Main()
    {
        var csvPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "data", "comics.csv");

        try 
        {
            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true });
            var comics = csv.GetRecords<Comic>().ToList();

            Console.WriteLine("\n1. Comics released before the year 2000:");
            foreach (var comic in comics.Where(c => c.ReleaseYear < 2000).OrderBy(c => c.ReleaseYear))
                Console.WriteLine($"{comic.Title} ({comic.ReleaseYear}) by {comic.Author}");

            Console.WriteLine("\n2. Number of comics written by each author:");
            foreach (var stat in comics.GroupBy(c => c.Author).Select(g => new { Author = g.Key, Count = g.Count() }).OrderByDescending(x => x.Count))
                Console.WriteLine($"{stat.Author}: {stat.Count} comics");

            Console.WriteLine("\n3. Most active author per year:");
            foreach (var year in comics.GroupBy(c => c.ReleaseYear)
                .Select(g => new {
                    Year = g.Key,
                    Author = g.GroupBy(c => c.Author).OrderByDescending(a => a.Count()).ThenBy(a => a.Key).First().Key,
                    Count = g.GroupBy(c => c.Author).OrderByDescending(a => a.Count()).First().Count()
                }).OrderBy(x => x.Year))
                Console.WriteLine($"{year.Year}: {year.Author} ({year.Count} comics)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}