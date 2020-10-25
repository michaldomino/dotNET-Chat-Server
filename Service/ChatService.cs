using dotNET_Chat_Server.Data;
using dotNET_Chat_Server.Entities;
using dotNET_Chat_Server.Models.Request;
using dotNET_Chat_Server.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Service
{
    public class ChatService : IChatService
    {
        private readonly ApplicationDbContext context;

        public ChatService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<CreatedChatResponseModel> AddAsync(Chat chat)
        {
            await context.Chats.AddAsync(chat);
            await context.SaveChangesAsync();
            return new CreatedChatResponseModel { Id = chat.Id, Name = chat.Name };
        }

        public async Task<AddUsersToChatResponseModel> AddUsersToChatAsync(Guid chatId, AddUsersToChatRequestModel requestModel)
        {
            Chat chatToAddUsersTo = await GetChat(chatId);
            var chatMembersBeforeAdd = await GetChatMembers(chatId);
            var chatMembersIdsBeforeAdd = chatMembersBeforeAdd.Select(it => it.Id);
            var userIdsToAdd = requestModel.UsersIds.Where(it => !chatMembersIdsBeforeAdd.Contains(it));

            var applictaionUsersToAdd = userIdsToAdd.Select(it => new ApplicationUserChat
            {
                ApplicationUserId = it,
                ChatId = chatId
            });
            await context.ApplicationUserChats.AddRangeAsync(applictaionUsersToAdd);
            await context.SaveChangesAsync();

            var chatMembersAfterAdd = await GetChatMembers(chatId);
            return new AddUsersToChatResponseModel
            {
                CurrentChatUsers = chatMembersAfterAdd.Select(it => new ApplicationUserSearchResponseModel
                {
                    Id = it.Id,
                    UserName = it.UserName
                }).ToList()
            };
        }

        public Task<Chat> GetChat(Guid chatId)
        {
            return context.Chats.FirstAsync(it => it.Id == chatId);
        }

        public Task<List<ApplicationUser>> GetChatMembers(Guid chatId)
        {
            return context.ApplicationUserChats.Where(it => it.ChatId == chatId).Select(it => it.ApplicationUser).ToListAsync();
        }
    }
}
