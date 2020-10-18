using dotNET_Chat_Server.Models;
using dotNET_Chat_Server.Models.Request;
using dotNET_Chat_Server.Models.Response;
using dotNET_Chat_Server.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtOptions jwtOptions;

        public AuthenticationService(UserManager<ApplicationUser> userManager, JwtOptions jwtOptions)
        {
            this.userManager = userManager;
            this.jwtOptions = jwtOptions;
        }

        public async Task<AuthenticationResponseModel> RegisterApplicationUserAsync(ApplicationUserRegisterRequestModel requestModel)
        {
            if (await userManager.FindByNameAsync(requestModel.UserName) != null)
            {
                return new AuthenticationResponseModel
                {
                    Errors = new[] { $"User name {requestModel.UserName} already exists." }
                };
            }
            ApplicationUser newUser = new ApplicationUser
            {
                UserName = requestModel.UserName,
                Email = requestModel.Email,
            };
            IdentityResult createdUser = await userManager.CreateAsync(newUser, requestModel.Password);
            if (!createdUser.Succeeded)
            {
                return new AuthenticationResponseModel
                {
                    Errors = createdUser.Errors.Select(it => it.Description)
                };
            }
        }
    }
}
