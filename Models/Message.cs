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
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }

        //[ForeignKey("AuthorId")]
        [Required]
        public ApplicationUser Author { get; set; }
        //public Guid AuthorId { get; set; }

        //[ForeignKey("RecipientId")]
        //[Required]
        public ApplicationUser Recipient { get; set; }
        //public Guid? RecipientId { get; set; }
    }
}
