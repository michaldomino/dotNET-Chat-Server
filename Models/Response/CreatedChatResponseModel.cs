using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Models.Response
{
    public class CreatedChatResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
