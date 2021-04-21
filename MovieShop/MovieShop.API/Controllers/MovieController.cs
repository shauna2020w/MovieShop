using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
//Api methods will return json data along with http status code
//200 OK
//201 Created
//400 bad request when validation fails
//401 Login failed
//403forbiden, no permision
//404 not found
//500 exception happened on the server, internal server error, try again later

{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieService movieService,IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            _movieService = movieService;
        }

        [HttpGet]
        [Route("toprevenue")] //attribute based routing
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.Get30HighestGrossing();

            if (!movies.Any())
            {
                return NotFound("We didnt find any movies.");
            }
            return Ok(movies);

            //system.text.json in .net core 3
            //previous  versions of .net 1,2 and previous older .net framework newtonsoft, 3rd party lib
            //Serialication, convert your c# objects into json objects
            //De-Serialization , convert json obj to c#
        }

        //[HttpGet]
        //[Route("{id}")] //attribute based routing
        //public async Task<IActionResult> GetMovieById(int movieId)
        //{
        //    var m = await _movieRepository.GetByIdAsync(movieId);

        //    if (m == null)
        //    {
        //        return NotFound("We didnt find any movies.");
        //    }
        //    return Ok(m);
        //}

        [HttpGet]
        [Route("genre/{genreId}")] //attribute based routing
        public async Task<IActionResult> GetMovieByGenre(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenreId(genreId);

            if (!movies.Any())
            {
                return NotFound("We didnt find any movies.");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("{movieId}")] //attribute based routing
        public async Task<IActionResult> GetMovieDetails(int movieId)
        {
            var details = await _movieService.GetMovieDetailByMovieId(movieId);

            return Ok(details);
        }
    }
}