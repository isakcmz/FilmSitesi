using Microsoft.AspNetCore.Identity;

namespace FilmSitesi.Web.Models.Entities;

public class AppUser : IdentityUser
{
    public List<Review> Reviews { get; set; } = new();
    public List<WatchlistItem> WatchlistItems { get; set; } = new();
}