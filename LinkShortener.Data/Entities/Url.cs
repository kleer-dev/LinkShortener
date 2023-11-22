namespace LinkShortener.Data.Entities;

public class Url
{
    public int Id { get; set; }
    public string LongUrl { get; set; } = string.Empty;
    public string ShortenedUrl { get; set; } = string.Empty;
    public DateTime DateOfCreation { get; set; }
    public int TransitionCount { get; set; }
}