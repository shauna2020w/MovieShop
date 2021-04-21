using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequestModel);
        Task<UserLoginResponseModel> ValidateUser(string email, string password);
        
        //void LoginAccount(UserLoginRequestModel model);
        //void GetPurchasedMovie(/*MoviePurchaseRequestModel model*/);
        //void CreateReview(MovieReviewRequestModel model);
        Task<AccountInfoResponseModel> AccountInfo(int id);
    }
}

