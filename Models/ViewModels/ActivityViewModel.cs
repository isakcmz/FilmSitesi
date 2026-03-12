namespace FilmSitesi.Web.Models.ViewModels;

public class ActivityViewModel
{
    public string UserName { get; set; } = string.Empty;

    public string MovieTitle { get; set; } = string.Empty;

    public int MovieTmdbId { get; set; }

    public string Type { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}