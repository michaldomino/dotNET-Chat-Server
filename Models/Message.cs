using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }

        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }
        public Guid AuthorId { get; set; }

        [ForeignKey("RecipientId")]
        public ApplicationUser Recipient { get; set; }
        public Guid RecipientId { get; set; }
    }
}
