namespace FilmSitesi.Web.Models.Entities;

public class Movie
{
    public int Id { get; set; }

    public int TmdbId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string OriginalTitle { get; set; } = string.Empty;

    public string Overview { get; set; } = string.Empty;

    public DateTime? ReleaseDate { get; set; }

    public string PosterPath { get; set; } = string.Empty;

    public string BackdropPath { get; set; } = string.Empty;

    public double VoteAverage { get; set; }

    public string OriginalLanguage { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}