using dotNET_Chat_Server.Models.Request;
using dotNET_Chat_Server.Service;
using dotNET_Chat_Server.ValueModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        // POST: api/Authentication/Register
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

        // POST: api/Authentication/Login
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
