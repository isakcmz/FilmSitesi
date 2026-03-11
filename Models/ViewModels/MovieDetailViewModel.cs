using FilmSitesi.Web.Models.Entities;

namespace FilmSitesi.Web.Models.ViewModels;

public class MovieDetailViewModel
{
    public Movie Movie { get; set; } = null!;

    public double? UserRating { get; set; }

    public string UserComment { get; set; } = string.Empty;

    public List<Review> Reviews { get; set; } = new();
}