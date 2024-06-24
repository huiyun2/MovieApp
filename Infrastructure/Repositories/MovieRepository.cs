using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;

namespace Infrastructure.Repositories;

public class MovieRepository: EfRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
    {

    }
    public async Task<IEnumerable<Movie>> GetTop30RevenueMovies()
    {   // EF Core or Dapper
        // they provide both sync and async methods in those libraries
        // get top 30 movies by revenue
        var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
        return movies;

    }

public override async Task<Movie> GetById(int id)
{
    var movieDetails = await _dbContext.Movies
        .Include(m => m.Genres)  
        .ThenInclude(g => g.Genre)  
        .Include(m => m.Trailers)  
        .FirstOrDefaultAsync(m => m.Id == id); 
    return movieDetails;
}
public async Task<PagedResultSet<Movie>> GetMoviesByGenres(int genreId, int pageSize =30, int pageNumber = 1)
{
    //get total movies count for that genre
    var totalMoviesCountByGenre = await _dbContext.MovieGenre.Where(m => m.GenreId == genreId).CountAsync();

    // get the actual movies from MovieGenre and Movie Table
    if (totalMoviesCountByGenre == 0)
    {
        throw new Exception("No Movies Found for that genre.");
    }

    var movies = await _dbContext.MovieGenre.Where(g => g.GenreId == genreId).Include(m => m.Movie)
        .OrderBy(m => m.MovieId)
        .Select(m => new Movie{
            Id = m.MovieId, 
            PosterUrl = m.Movie.PosterUrl, 
            Title = m.Movie.Title
        }).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

    var pagedMovies =  new PagedResultSet<Movie>(movies, pageNumber, pageSize, totalMoviesCountByGenre);
    return pagedMovies;

}

}