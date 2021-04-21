using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> Get30HighestGrossing(); //??
        Task<List<MovieCardResponseModel>> GetMoviesByGenreId(int id);
        Task<MovieDetailResponseModel> GetMovieDetailByMovieId(int id);
        Task<IEnumerable<MovieReviewResponseModel>> GetMovieReviewByMovieId(int id);
        void CreateMovieAsync(MovieCreateRequestModel model);
        void PurchaseMovie(MoviePurchaseRequestModel model);
        void ReviewMovie(MovieReviewRequestModel model);
        void WatchMovie(MovieWatchRequestModel model);

    }
}
