using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotNET_Chat_Server.Entities
{
    public class Chat
    {
        public Chat()
        {
            Messages = new HashSet<Message>();
            ApplicationUserChats = new HashSet<ApplicationUserChat>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<ApplicationUserChat> ApplicationUserChats { get; set; }
    }
}
