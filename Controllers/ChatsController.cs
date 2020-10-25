using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotNET_Chat_Server.Data;
using dotNET_Chat_Server.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using dotNET_Chat_Server.ValueModels;
using dotNET_Chat_Server.Service;
using dotNET_Chat_Server.Models.Response;
using dotNET_Chat_Server.Models.Request;
using dotNET_Chat_Server.Extensions;

namespace dotNET_Chat_Server.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class ChatsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IChatService chatService;

        public ChatsController(ApplicationDbContext context)
        {
            _context = context;
            chatService = new ChatService(context);
        }

        // POST: api/Chats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CreatedChatResponseModel>> PostChat([FromBody] Chat chat)
        {
            CreatedChatResponseModel createdChat = await chatService.AddAsync(chat);
            return CreatedAtAction("GetChat", new { id = chat.Id }, createdChat);
        }

        [HttpPost(RoutesModel.Api.Chats.AddUsers + "/{chatId}")]
        public async Task<ActionResult<AddUsersToChatResponseModel>> AddUsersToChat(Guid chatId, [FromBody] AddUsersToChatRequestModel requestModel)
        {
            AddUsersToChatResponseModel addUsersToChatResponseModel = await chatService.AddUsersToChatAsync(chatId, requestModel);
            return Ok(addUsersToChatResponseModel);
        }

        [HttpPost(RoutesModel.Api.Chats.SendMessage + "/{chatId}")]
        public async Task<ActionResult<MessageResponseModel>> SendMessage(Guid chatId, [FromBody] NewMessageRequestModel requestModel)
        {
            Guid userId = HttpContext.GetUserId();
            MessageResponseModel createdMessage = await chatService.AddMessageToChatAsync(chatId, userId, requestModel);
            return CreatedAtAction("SendMessage", new { id = createdMessage.Id }, createdMessage);
        }

        [HttpGet(RoutesModel.Api.Chats.GetMessages + "/{chatId}")]
        public async Task<ActionResult<List<MessageResponseModel>>> GetMessage(Guid chatId)
        {
            List<MessageResponseModel> messages = await chatService.GetMessages(chatId);
            return Ok(messages);
        }
    }
}
