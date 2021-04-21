using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(UserLoginResponseModel model)
        {
            // Create Claims that needs to be stored in Payload of the token
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, model.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, model.LastName),
                new Claim(JwtRegisteredClaimNames.Email, model.Email)
            };

            // create identity object and store above claims
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            // read the secret key from app settings, make sure secret key is unique and non guessable
            // In real world we use something like Azure Key/Vault to store the secret keys, database connection strings
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenSetting:PrivateKey"]));

            // Pick an Hashing algorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // establish JWT expiration time
            var expires = DateTime.UtcNow.AddDays(_config.GetValue<int>("TokenSetting:Expiration"));

            var tokenHandler = new JwtSecurityTokenHandler();

            // create token object with all the information you need to create token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = _config["TokenSetting:Issuer"],
                Audience = _config["TokenSetting:Audience"]
            };

            var encodedJwt = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(encodedJwt);
        }
    }
}
