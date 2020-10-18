using dotNET_Chat_Server.Models;
using dotNET_Chat_Server.Models.Request;
using dotNET_Chat_Server.Service;
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

        [HttpPost("api/authentication/register")]
        public async Task<IActionResult> RegisterApplicationUser([FromBody] ApplicationUserRegisterRequestModel requestModel)
        {
            var response = await authenticationService.RegisterApplicationUserAsync(requestModel);
        }
    }
}
