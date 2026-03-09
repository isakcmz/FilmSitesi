using FilmSitesi.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmSitesi.Web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>()
            .HasIndex(m => m.TmdbId)
            .IsUnique();

        modelBuilder.Entity<Movie>()
            .Property(m => m.Title)
            .HasMaxLength(200);

        modelBuilder.Entity<Movie>()
            .Property(m => m.OriginalTitle)
            .HasMaxLength(200);

        modelBuilder.Entity<Movie>()
            .Property(m => m.OriginalLanguage)
            .HasMaxLength(20);
    }
}