using FilmSitesi.Web.Models.ViewModels;
using FilmSitesi.Web.Services;
using FilmSitesi.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;


namespace FilmSitesi.Web.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;
    private readonly ITmdbService _tmdbService;


    public MoviesController(IMovieService movieService, ITmdbService tmdbService)
    {
        _movieService = movieService;
        _tmdbService = tmdbService;
    }


    public async Task<IActionResult> Detail(int id)
    {
        var movie = await _movieService.GetOrCreateMovieAsync(id);

        if (movie == null)
            return NotFound();

        return View(movie);
    }



    [HttpGet]
    public IActionResult Search()
    {
        return View(new MovieSearchViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Search(MovieSearchViewModel model)
    {
        if (!string.IsNullOrWhiteSpace(model.Query))
        {
            model.Results = await _tmdbService.SearchMoviesAsync(model.Query);
        }

        return View(model);
    }
}