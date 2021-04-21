using ApplicationCore.Models.Request;
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
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AccountController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel registerRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check data");
            }
            var registeredUser = await _userService.RegisterUser(registerRequestModel);

            return Ok(registeredUser);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(UserLoginRequestModel model)
        {
            var user = await _userService.ValidateUser(model.Email, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var jwtToken = _jwtService.GenerateToken(user);
            // generate a JWT token and send it to Client
            return Ok(new { token = jwtToken });
        }


    }
}
