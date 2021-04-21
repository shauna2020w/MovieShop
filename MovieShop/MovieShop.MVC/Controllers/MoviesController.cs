using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Services;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.Extensions.Logging;
using ApplicationCore.Models.Response;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller    //use movies to open this page
    {   

        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        //public IActionResult Index()
        //{
        //    // it will look for a view in view folder called Index, which = action name

        //    // if wanna show another view like Index2 as test view.  return View("Index2");
        //    //1.ViewBag 2. ViewData 3.** Strongly Typed Model
        //    //send list of top 30 movies to the view
        //    //id, title,posterUrl

        //    //ViewBag.PageTitle = "Top 30 grossing moives"
        //    var movies = _movieService.Get30HighestGrossing();
        //    return View(movies); // pass obj to the view, "strongly typed model"
        //}

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.Get30HighestGrossing();
            return View(movies);
        }


        //we want to show blank page with all the inputs

        [HttpGet] //attitude
        public IActionResult Create() // 
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            //var result = new List<MovieDetailResponseModel>();
            var detail  = await _movieService.GetMovieDetailByMovieId(id);
            //result.Add(detail);
            return View(detail);
        }

        [HttpGet]
        public async Task<IActionResult> MoviesOfGenre(int Id)
        {
            var movies = await _movieService.GetMoviesByGenreId(Id);
            return View("MoviesOfGenre",movies);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateRequestModel model)
        {
            _movieService.CreateMovieAsync(model);
            return RedirectToAction("Index");
            //moved to IMovieService
        }     
    }
}
