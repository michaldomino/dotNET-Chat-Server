using Microsoft.AspNetCore.Http;
using System;

namespace dotNET_Chat_Server.Models.Response
{
    public class ApplicationUserSearchResponseModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}
