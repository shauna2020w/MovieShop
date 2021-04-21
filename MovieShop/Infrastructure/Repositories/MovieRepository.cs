using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Movie>> GetTop30HighestGrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            //skip,take
            return movies;
        }
        public async Task<IEnumerable<Movie>> GetAllMoviesByGrossing()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).ToListAsync();
            //skip,take
            return movies;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesByGenreId(int genreId)
        {
            var movies = await _dbContext.Genres.Include(g => g.Movies).Where(g => genreId == g.Id).SelectMany(g => g.Movies).OrderByDescending(m => m.Revenue).ToListAsync();
            
            //skip,take
            return movies;
        }

        public override Task<Movie> GetByIdAsync(int id)
        {
            return _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return await _dbContext.Reviews.OrderByDescending(r=>r.Rating).ToListAsync();
        }

        public async Task<IEnumerable<Cast>> GetCastsOfMovie(int movieId)
        {
            var mcs = await _dbContext.MovieCasts.Where(mc => mc.MovieId == movieId).ToListAsync();
            var castIds = new List<int>();
            foreach (var mc in mcs)
                { castIds.Add(mc.CastId); }
            var casts = await _dbContext.Casts.Where(c =>castIds.Contains(c.Id)).ToListAsync();
            
            //skip,take
            return casts;
        }
        public async Task<IEnumerable<Movie>> GetMoviesOfCast(int castId)
        {

            var mcs = await _dbContext.MovieCasts.Where(mc => mc.CastId == castId).ToListAsync();
            List<int> movieIds = new();

            foreach (var mc in mcs ){ movieIds.Add(mc.MovieId); }

            var movies = new List<Movie>();

            foreach (var id in movieIds)
            { movies.Add(await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id)); }
            
            //skip,take
            return movies;
        }
    }
}
