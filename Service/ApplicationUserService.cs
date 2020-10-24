using dotNET_Chat_Server.Data;
using dotNET_Chat_Server.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public List<Chat> GetChats(ApplicationUser applicationUser)
        {
            var chats = applicationUser.ApplicationUserChats.Select(it => it.Chat);
            return chats.ToList();
        }

        public async Task<List<Chat>> GetChatsAsync(Guid userId)
        {
            ApplicationUser applicationUser = await GetUser(userId);
            return GetChats(applicationUser);
        }

        public Task<ApplicationUser> GetUser(Guid id)
        {
            return context.ApplicationUsers.FirstAsync(it => it.Id == id);
        }
    }
}
