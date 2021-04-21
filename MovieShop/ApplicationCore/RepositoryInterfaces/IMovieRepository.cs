using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository: IAsyncRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllMoviesByGenreId(int genreId);
        Task<IEnumerable<Movie>> GetAllMoviesByGrossing();
        Task<IEnumerable<Movie>> GetTop30HighestGrossingMovies();
        Task<IEnumerable<Movie>> GetMoviesOfCast(int castId);
        Task<IEnumerable<Cast>> GetCastsOfMovie(int movieId);

        Task<IEnumerable<Review>> GetAllReviews();

    }
}
