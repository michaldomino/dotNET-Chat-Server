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
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
