using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieMVC.Models;
// using Infrastruture.Services;
using ApplicationCore.Contracts.Services;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MovieMVC.Controllers
{
    public class MoviesController: Controller
    {
        private IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> Details(int id)
        {
            // Movie Service with Details
            // Pass the movie details data to view
            // Data
            //Remote Database
            // CPU bound operation => PI => Loan Calculator, image processing
            // I/O bound operation => database calls, file, images, videos
            // Network speed, SQL Server => SQL query, Server Memory
            var movieDetails = await _movieService.GetMovieDetails(id);
            return View(movieDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Genres(int id, int pageSize=30, int pageNumber=1)
        {   
            var pageMovies = await _movieService.GetMoviesByGenresPagination(id, pageSize, pageNumber);
            return View("PagedMovies", pageMovies);
        }
    }
}