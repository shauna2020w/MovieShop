using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Filters
{
    public class MovieShopHeaderFilter : IActionFilter
    {
        private readonly ILoggerService _loggerService;

        public MovieShopHeaderFilter(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Log each and every user's IP address, his name if authenticated, authentication status, date time
            // context.HttpContext.Response.Headers.Add("job", "antra.com/jobs");

            var email = _loggerService.Email;
            var datetime = DateTime.UtcNow;
            var isAuthenticated = _loggerService.IsAuthenticated;
            var name = _loggerService.FullName;

            // log this info to text files
            // System.IO
            // Serilog, NLog, Log4net

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
