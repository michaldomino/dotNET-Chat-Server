using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNET_Chat_Server.Entities
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Text { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public ApplicationUser Author { get; set; }
        
        public Guid ChatId { get; set; }

        [ForeignKey(nameof(ChatId))]
        public Chat Chat { get; set; }
    }
}
