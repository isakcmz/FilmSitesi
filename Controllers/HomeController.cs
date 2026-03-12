using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FilmSitesi.Web.Models;
using FilmSitesi.Web.Models.ViewModels;
using FilmSitesi.Web.Data;
using Microsoft.EntityFrameworkCore;



namespace FilmSitesi.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var activities = await _context.Activities
            .Include(a => a.User)
            .Include(a => a.Movie)
            .OrderByDescending(a => a.CreatedAt)
            .Take(20)
            .Select(a => new ActivityViewModel
            {
                UserName = a.User.UserName ?? "",
                MovieTitle = a.Movie.Title,
                MovieTmdbId = a.Movie.TmdbId,
                Type = a.Type,
                CreatedAt = a.CreatedAt
            })
            .ToListAsync();

        return View(activities);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
