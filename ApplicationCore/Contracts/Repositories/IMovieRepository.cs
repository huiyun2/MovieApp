using ApplicationCore.Entities;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Repositories;


public interface IMovieRepository: IRepository<Movie>
{
   Task<IEnumerable<Movie>> GetTop30RevenueMovies();
   // totalcount, pagesize, pageNumber, TotalPages
   // PagedModel => 
   // Tuple 
   //Task <(IEnumerable<Movie>, int totalCount, int totalPages)> GetMoviesByGenres(int genreId, int pageSize =30, int pageNumber = 1);
   Task <PagedResultSet<Movie>> GetMoviesByGenres(int genreId, int pageSize =30, int pageNumber = 1);

}