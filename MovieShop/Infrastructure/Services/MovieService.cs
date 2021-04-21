using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public IEnumerable<object> Reviews { get; private set; }

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }



        public async Task<List<MovieCardResponseModel>> Get30HighestGrossing()
        {
            var movies = await _movieRepository.GetTop30HighestGrossingMovies();

            var result = new List<MovieCardResponseModel>();

            foreach (var movie in movies)
            {
                result.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }

            return result;
        }



        public async Task<List<MovieCardResponseModel>> GetMoviesByGenreId(int Id)
        {
            var movies = await _movieRepository.GetAllMoviesByGenreId(Id);

            var result = new List<MovieCardResponseModel>();

            foreach (var m in movies)
            {
                result.Add(new MovieCardResponseModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterUrl = m.PosterUrl
                });
            }

            return result;
        }

        public async Task<IEnumerable<MovieReviewResponseModel>> GetMovieReviewByMovieId(int id)
        {
            var reviews = await _movieRepository.GetAllReviews();

            var result = new List<MovieReviewResponseModel>();

            foreach (var r in reviews)
            {
                result.Add(new MovieReviewResponseModel
                {
                    UserId = r.UserId,
                    Rating = r.Rating,
                    ReviewContent = r.ReviewText,

                }) ;
            }

            return result;
        }
        //public async Task<List<MovieCardResponseModel>> GetMovieById(int id)
        //{
        //    var movie = await _movieRepository.GetByIdAsync(id);
        //    var result = new List<MovieCardResponseModel>();
        //    result.Add(new MovieCardResponseModel
        //    {
        //        Id = movie.Id,
        //        Title = movie.Title,
        //        PosterUrl = movie.PosterUrl
        //    });

        //    return result;
        //}

        public async Task<MovieDetailResponseModel> GetMovieDetailByMovieId(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            var CastTable = new List<CastModel>();
            var casts = await _movieRepository.GetCastsOfMovie(id);
            foreach(var c in casts)
            {
                var castModel = new CastModel
                {
                    Name = c.Name,
                    Gender = c.Gender,
                    ProfilePath = c.ProfilePath,
                    Movies = movie.Title  //initial movie info
                };
                foreach (var mc in c.MovieCasts) 
                {
                    var m = await _movieRepository.GetByIdAsync(mc.MovieId);
                    if (m.Id != movie.Id)
                    {
                        castModel.Movies = castModel.Movies+ "/" + m.Title;
                    }
                }
                CastTable.Add(castModel);
            }
            var result = new MovieDetailResponseModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Tagline = movie.Tagline,
                Runtime = movie.RunTime,
                CreatedDate = movie.CreatedDate,
                Genres = movie.Genres,
                Overview = movie.Overview,
                ReleaseDate = movie.ReleaseDate,
                PosterUrl = movie.PosterUrl,
                BoxOffice = movie.Revenue,
                Budget = movie.Budget,
                Rating = movie.Rating,
                CastCollection = CastTable
            }; 

            return result;
        }


        public void CreateMovieAsync(MovieCreateRequestModel model)
        {
            // take model and convert it to Movie Entity and send it to repository
            // if repository saves successfully return true/id:2
            ApplicationCore.Entities.Movie movie = new();
            movie.Title = model.Title;
            movie.Overview = model.Overview;
            movie.Tagline = model.Tagline;
            movie.CreatedDate = model.CreatedTime;
            movie.CreatedBy = model.CreatedBy;
            movie.Budget = model.Budget;
            movie.Revenue = model.Revenue;

           // return  _movieRepository.AddAsync(Movie movie);

        }
        
        public void PurchaseMovie(MoviePurchaseRequestModel model)
        {
            throw new NotImplementedException();
        }

        public void ReviewMovie(MovieReviewRequestModel model)
        {
            throw new NotImplementedException();
        }

        public void WatchMovie(MovieWatchRequestModel model)
        {
            throw new NotImplementedException();
        }

       
    }
}
