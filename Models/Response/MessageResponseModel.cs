using System;

namespace dotNET_Chat_Server.Models.Response
{
    public class MessageResponseModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorUserName { get; set; }
    }
}
