using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interface;
using Infrastructure.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> signInManager;

        public AccountService(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        
        //Register User
        public async Task<BaseResponse> RegisterUser(RegisterUserRequest request)
        {
            //create new user
            User user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                AccountConfirmation = false
            };

            //set default password
            string password = Constants.DEFAULT_PASSWORD;
            

            
            var result = await signInManager.UserManager.CreateAsync(user, password);
            //return response
            return new BaseResponse
            {
                //checks if identity operation was successful 
                IsSuccess = result.Succeeded

            };
        }

        public async Task<BaseResponse<string>> VerifyUser(string email, string password)
        {
            BaseResponse<string> response = new();

            //get user email
            var user = await signInManager.UserManager.FindByEmailAsync(email);

            //checks if email exists
            if (user == null) {

                response.ErrorMessage = "User not found!";
                response.IsSuccess = false;
                return response;
            }

            //checks password email combo
            var result = await signInManager.UserManager.CheckPasswordAsync(user, password);
            response.IsSuccess = true;
            if (result == false)
            {
                response.ErrorMessage = "Invalid Email/Password";
            }
            else {
                response.Value = user.UserName; 
            }
            return response;

        }   
    }
}
