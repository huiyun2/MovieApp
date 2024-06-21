using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieAppMVC.Models;

namespace MovieAppMVC.Controllers;

public class HomeController : Controller
{


    [HttpGet]
    public IActionResult Index()
    {
        // our controllers are very thin/lean
        // most of your logic should come from other dependencies, services
        // Interfaces
        var movieService = new MovieService();
        // model data
        var movies = movieService.GetTop30GrossingMovies();
        return View(movies);
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult TopMovies()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
