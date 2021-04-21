using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequestModel)
        {
            // first check whether email exists in database
            var dbUser = await _userRepository.GetUserByEmail(registerRequestModel.Email);

            // user exists in database
            if (dbUser != null)
            {
                throw new ConflictException("user already exists, please login");
            }

            var salt = CreateSalt();

            //var saltExistsDb = await _userRepository.SaltExist(salt);
            //if(!saltExistsDb)
            //{
            //    //countinue
            //}

            var hashedPassword = HashPassword(registerRequestModel.Password, salt);

            var user = new User
            {
                FirstName = registerRequestModel.FirstName,
                LastName = registerRequestModel.LastName,
                Email = registerRequestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                DateOfBirth = registerRequestModel.DateOfBirth
            };


            var createdUser = await _userRepository.AddAsync(user);
            var createdUserResponseModel = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };

            return createdUserResponseModel;
        }

        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string HashPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }



        public async Task<UserLoginResponseModel> ValidateUser(string email, string password)
        {
            // we should go to database and get the record by email

            var dbUser = await _userRepository.GetUserByEmail(email);

            if (dbUser == null)
            {
                return null;
            }

            var hashedPassword = HashPassword(password, dbUser.Salt);
            if (hashedPassword == dbUser.HashedPassword)
            {
                // user entered correct password
                var loginUserResponse = new UserLoginResponseModel
                {
                    Id = dbUser.Id,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    Email = dbUser.Email
                };
                return loginUserResponse;
            }

            return null;
        }


        public Task<AccountInfoResponseModel> AccountInfo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
