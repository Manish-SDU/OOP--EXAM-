public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public string Genres { get; set; }
    public List<string> GenresList => Genres.Split('|').ToList();
}
