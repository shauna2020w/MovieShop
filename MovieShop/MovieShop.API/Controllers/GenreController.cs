using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMovieService _movieService;

        public GenreController(IGenreService genreService, IMovieService movieService)
        {
            _genreService = genreService;
            _movieService = movieService;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetallGenres()
        {
            var genres = await _genreService.GetAllGenres();

            return Ok(genres);
        }

    }
}
