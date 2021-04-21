using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{

    public class UserController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetUserPurchasedMovies()
        {   
            //call user service by in fo user to get all movies purchased

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult PurchaseMovie()
        {
            return View();
        }
    }
}
