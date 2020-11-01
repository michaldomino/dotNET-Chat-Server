using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Models.Response
{
    public class AddUsersToChatResponseModel
    {
        public ICollection<ApplicationUserResponseModel> CurrentChatMembers { get; set; }
    }
}
