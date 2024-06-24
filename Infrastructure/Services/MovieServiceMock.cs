// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// using ApplicationCore.Contracts.Services;
// using ApplicationCore.Models;
// namespace Infrastruture.Services
// {
//     public class MovieServiceMock: IMovieService
//     {
//         public List<MovieCardModel> GetTop30GrossingMovies()
//         {
//             // call movieRepository(call the database with Dapper or EF Core)
//             var movies = new List<MovieCardModel>(){
//                 new MovieCardModel {Id = 1, PosterUrl = "", Title = "Inception"},
//                 new MovieCardModel {Id = 2, PosterUrl = "", Title = "Interstellar"},
//                 new MovieCardModel {Id = 2, PosterUrl = "", Title = "The Dark Knight"}
//             };
//             return movies;
//         }
       
//     }
// }