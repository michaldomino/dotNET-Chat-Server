using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Models.Response
{
    public class AuthenticationResponseModel
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
