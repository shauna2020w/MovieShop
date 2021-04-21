using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class LoggerService : ILoggerService   //Current User
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggerService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? UserId =>
           Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User.Identity != null &&
                                     _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public string Email => _httpContextAccessor.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        public string FullName => _httpContextAccessor.HttpContext?.User.Claims
                                    .FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + " " +
                                _httpContextAccessor.HttpContext?.User.Claims
                                    .FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;



        public string ProfilePicture { get; }

        public string RemoteIpAddress => _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();

        public bool IsAdmin { get; }

        public bool IsSuperAdmin { get; }

        public IEnumerable<string> Roles { get; }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            throw new NotImplementedException();
        }


    }
}
