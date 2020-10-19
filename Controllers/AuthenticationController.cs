using dotNET_Chat_Server.Models;
using dotNET_Chat_Server.Models.Request;
using dotNET_Chat_Server.Service;
using dotNET_Chat_Server.ValueModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost(RoutesModel.Api.Authentication.Register)]
        public async Task<IActionResult> RegisterApplicationUser([FromBody] ApplicationUserRegisterRequestModel requestModel)
        {
            var response = await authenticationService.RegisterApplicationUserAsync(requestModel);
            if (!response.Success)
            {
                return new BadRequestObjectResult(response);
            }
            return Ok(response);
        }

        [HttpPost(RoutesModel.Api.Authentication.Login)]
        public async Task<IActionResult> LoginApplicationUser([FromBody] ApplicationUserLoginRequestModel requestModel)
        {
            var response = await authenticationService.LoginApplicationUserAsync(requestModel);
            if (!response.Success)
            {
                return new BadRequestObjectResult(response);
            }
            return Ok(response);
        }
    }
}
