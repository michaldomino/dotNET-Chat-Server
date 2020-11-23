using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNET_Chat_Server.Entities
{
    public class ApplicationUserChat
    {
        [Key]
        public Guid ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        public Guid ChatId { get; set; }

        [ForeignKey(nameof(ChatId))]
        public Chat Chat { get; set; }
    }
}
