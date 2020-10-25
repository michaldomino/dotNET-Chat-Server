using System;
using System.Collections.Generic;

namespace dotNET_Chat_Server.Models.Request
{
    public class AddUsersToChatRequestModel
    {
        public ICollection<Guid> UsersIds { get; set; }
    }
}
