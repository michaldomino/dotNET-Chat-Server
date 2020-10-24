using dotNET_Chat_Server.Entities;
using dotNET_Chat_Server.Models.Request;
using dotNET_Chat_Server.Models.Response;
using dotNET_Chat_Server.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
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
                    Success = false,
                    Errors = new[] { $"User name {requestModel.UserName} already exists." }
                };
            }

            var newUser = new ApplicationUser
            {
                UserName = requestModel.UserName,
                Email = requestModel.Email,
            };

            var createdUser = await userManager.CreateAsync(newUser, requestModel.Password);
            if (!createdUser.Succeeded)
            {
                return new AuthenticationResponseModel
                {
                    Success = false,
                    Errors = createdUser.Errors.Select(it => it.Description)
                };
            }

            return GenerateSecurityToken(newUser);
        }

        public async Task<AuthenticationResponseModel> LoginApplicationUserAsync(ApplicationUserLoginRequestModel requestModel)
        {
            var loggedUser = await userManager.FindByNameAsync(requestModel.UserName);
            if (loggedUser == null)
            {
                return new AuthenticationResponseModel
                {
                    Success = false,
                    Errors = new[] { $"User name {requestModel.UserName} does not exist." }
                };
            }

            var isPasswordValid = await userManager.CheckPasswordAsync(loggedUser, requestModel.Password);
            if (!isPasswordValid)
            {
                return new AuthenticationResponseModel
                {
                    Success = false,
                    Errors = new[] { "Wrong username or password" }
                };
            }

            return GenerateSecurityToken(loggedUser);
        }

        private AuthenticationResponseModel GenerateSecurityToken(ApplicationUser applicationUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtOptions.Key);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, applicationUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, applicationUser.Email),
                    new Claim("id", applicationUser.Id.ToString()),
                }),
                //Expires = DateTime.UtcNow.AddDays(1);
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
            };

            var securityToken = tokenHandler.CreateToken(securityTokenDescriptor);
            return new AuthenticationResponseModel
            {
                Success = true,
                Token = tokenHandler.WriteToken(securityToken),
            };
        }
    }
}
