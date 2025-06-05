using CsvHelper.Configuration.Attributes;

namespace Comics.Models;

public class Comic
{
    [Name("Title")]
    public string Title { get; set; } = string.Empty;
    
    [Name("Author")]
    public string Author { get; set; } = string.Empty;
    
    [Name("Year")]
    public int Year { get; set; }
}
