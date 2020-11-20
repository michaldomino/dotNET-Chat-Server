using dotNET_Chat_Server.Data;
using dotNET_Chat_Server.Entities;
using dotNET_Chat_Server.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Service
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ApplicationUserResponseModel>> SearchAllUsersAsync()
        {
            var users = context.ApplicationUsers;
            return await users
                .Select(it => new ApplicationUserResponseModel { Id = it.Id, UserName = it.UserName })
                .ToListAsync();
        }

        public Task<List<Chat>> GetChatsAsync(ApplicationUser applicationUser)
        {
            return context.ApplicationUserChats.Where(it => it.ApplicationUserId == applicationUser.Id).Select(it => it.Chat).ToListAsync(); 
        }

        public async Task<List<Chat>> GetChatsAsync(Guid userId)
        {
            ApplicationUser applicationUser = await GetUser(userId);
            return await GetChatsAsync(applicationUser);
        }

        public Task<ApplicationUser> GetUser(Guid id)
        {
            return context.ApplicationUsers.FirstAsync(it => it.Id == id);
        }
    }
}
