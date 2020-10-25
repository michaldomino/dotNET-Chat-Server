﻿using dotNET_Chat_Server.Entities;
using dotNET_Chat_Server.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Service
{
    public interface IApplicationUserService
    {
        List<Chat> GetChats(ApplicationUser applicationUser);
        Task<List<Chat>> GetChatsAsync(Guid userId);
        Task<ApplicationUser> GetUser(Guid id);
        Task<List<ApplicationUserSearchResponseModel>> SearchAllUsersAsync();
    }
}
