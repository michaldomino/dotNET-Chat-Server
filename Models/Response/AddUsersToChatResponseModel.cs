using System.Collections.Generic;

namespace dotNET_Chat_Server.Models.Response
{
    public class AddUsersToChatResponseModel
    {
        public ICollection<ApplicationUserResponseModel> CurrentChatMembers { get; set; }
    }
}
