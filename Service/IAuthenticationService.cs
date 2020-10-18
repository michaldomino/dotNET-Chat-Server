using dotNET_Chat_Server.Models.Request;
using dotNET_Chat_Server.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Service
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponseModel> RegisterApplicationUserAsync(ApplicationUserRegisterRequestModel requestModel);
    }
}
