using dotNET_Chat_Server.Entities;
using dotNET_Chat_Server.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Service
{
    public interface IApplicationUserService
    {
        Task<List<Chat>> GetChatsAsync(ApplicationUser applicationUser);
        Task<List<Chat>> GetChatsAsync(Guid userId);
        Task<ApplicationUser> GetUser(Guid id);
        Task<List<ApplicationUserResponseModel>> SearchAllUsersAsync();
    }
}
