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
            var newApplicationUsersChats = requestModel.UsersIds.Select(it => new ApplicationUserChat { ApplicationUserId = it, ChatId = chatId });
            var existingApplicationUsersChats = context.ApplicationUserChats;
            HashSet<Tuple<Guid, Guid>> applicationUserChatsToExclude =
                new HashSet<Tuple<Guid, Guid>>(existingApplicationUsersChats.Select(it => new Tuple<Guid, Guid>(it.ApplicationUserId, it.ChatId)));

            List<ApplicationUserChat> applicationUserChatsToAdd = newApplicationUsersChats
                .Where(it => !applicationUserChatsToExclude.Contains(new Tuple<Guid, Guid>(it.ApplicationUserId, it.ChatId))).ToList();
            Chat chatToAddUsersTo = await GetChat(chatId);
            ApplicationUserService applicationUserService = new ApplicationUserService(context);
            List<ApplicationUserChat> applicationUserChatsToAdd2 = new List<ApplicationUserChat>();
            foreach (ApplicationUserChat applicationUserChatToAdd in applicationUserChatsToAdd)
            {
                applicationUserChatsToAdd2.Add(new ApplicationUserChat
                {
                    ApplicationUser = await applicationUserService.GetUser(applicationUserChatToAdd.ApplicationUserId),
                    Chat = chatToAddUsersTo
                });
                //applicationUserChatToAdd.ApplicationUser = 
                //applicationUserChatToAdd.Chat = chatToAddUsersTo;
            }
            await context.ApplicationUserChats.AddRangeAsync(applicationUserChatsToAdd2);
            await context.SaveChangesAsync();

            return new AddUsersToChatResponseModel
            {
                CurrentChatUsers = applicationUserChatsToAdd2.Select(it => new ApplicationUserSearchResponseModel
                {
                    Id = it.ApplicationUserId,
                    UserName = it.ApplicationUser.UserName
                }).ToList()
            };
        }

        public Task<Chat> GetChat(Guid id)
        {
            return context.Chats.FirstAsync(it => it.Id == id);
        }
    }
}
