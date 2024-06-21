using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services

public class MovieService : IMovieService
{
    public List<MovieCardModel> GetTop30GrossingMovies()
    {
        // call MovieRepository(call the database with Dapper or EF core)
        var movies = new List<MovieCardModel>(){
            new MovieCardModel { Id = 1, PosterUrl = "", Title ="Inception"},
            new MovieCardModel { Id = 2, PosterUrl = "", Title ="Interstellar"}
        }
        return movies;
    }
}