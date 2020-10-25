using dotNET_Chat_Server.Entities;
using dotNET_Chat_Server.Models.Request;
using dotNET_Chat_Server.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Service
{
    public interface IChatService
    {
        Task<CreatedChatResponseModel> AddAsync(Chat chat);
        Task<AddUsersToChatResponseModel> AddUsersToChatAsync(Guid chatId, AddUsersToChatRequestModel requestModel);
        Task<Chat> GetChat(Guid chatId);
        Task<List<ApplicationUser>> GetChatMembers(Guid chatId);
        Task<MessageResponseModel> AddMessageToChatAsync(Guid chatId, Guid userId, NewMessageRequestModel requestModel);
        Task<List<MessageResponseModel>> GetMessages(Guid chatId);
    }
}
