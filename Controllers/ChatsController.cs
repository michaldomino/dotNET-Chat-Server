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

namespace dotNET_Chat_Server.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        // GET: api/Chats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChats()
        {
            return await _context.Chats.ToListAsync();
        }

        // GET: api/Chats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> GetChat(Guid id)
        {
            var chat = await _context.Chats.FindAsync(id);

            if (chat == null)
            {
                return NotFound();
            }

            return chat;
        }

        // PUT: api/Chats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChat(Guid id, Chat chat)
        {
            if (id != chat.Id)
            {
                return BadRequest();
            }

            _context.Entry(chat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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
            var a = 0;
            return Ok(new AddUsersToChatResponseModel());
            //CreatedChatResponseModel createdChat = await chatService.AddAsync(chat);
            //return CreatedAtAction("GetChat", new { id = chat.Id }, createdChat);
        }

        // DELETE: api/Chats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chat>> DeleteChat(Guid id)
        {
            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();

            return chat;
        }

        private bool ChatExists(Guid id)
        {
            return _context.Chats.Any(e => e.Id == id);
        }
    }
}
