using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Models.Request
{
    public class ApplicationUserLoginRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
