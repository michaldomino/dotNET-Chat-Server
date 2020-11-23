using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotNET_Chat_Server.Data;
using Microsoft.AspNetCore.Identity;
using dotNET_Chat_Server.Entities;
using dotNET_Chat_Server.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using dotNET_Chat_Server.Extensions;
using dotNET_Chat_Server.ValueModels;
using dotNET_Chat_Server.Models.Response;

namespace dotNET_Chat_Server.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    //[ApiController]
    public class ApplicationUsersController : ControllerBase
    {
        private readonly IApplicationUserService applicationUserService;

        public ApplicationUsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            applicationUserService = new ApplicationUserService(context);
        }

        // GET: api/ApplicationUsers/Search
        [HttpGet(RoutesModel.Api.Users.Search)]
        public async Task<ActionResult<IEnumerable<ApplicationUserResponseModel>>> SearchApplicationUsers()
        {
            return Ok(await applicationUserService.SearchAllUsersAsync());
        }

        // GET: api/ApplicationUsers/Chats
        [HttpGet(RoutesModel.Api.Users.Chats)]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChats()
        {
            var userId = HttpContext.GetUserId();
            List<Chat> chats = await applicationUserService.GetChatsAsync(userId);
            List<ChatResponseModel> chatResponseModels = chats.Select(it => new ChatResponseModel
            {
                Id = it.Id,
                Name = it.Name
            }).ToList();
            return Ok(chatResponseModels);
        }
    }
}
