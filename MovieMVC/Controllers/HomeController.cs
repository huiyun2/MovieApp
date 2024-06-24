using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models;
using Infrastructure.Services;
using ApplicationCore.Contracts.Services;

namespace MovieMVC.Controllers;

public class HomeController : Controller
{
    private readonly IMovieService _movieService;
    public HomeController(IMovieService movieService)
    {
        _movieService = movieService;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        // var movieService = new MovieService();
        // model data
        var movies = await _movieService.GetTop30GrossingMovies();
        
        return View(movies);
    }
    [HttpGet]
    public IActionResult TopMovies(){
        return View();
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
