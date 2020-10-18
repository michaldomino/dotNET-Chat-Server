using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get => base.Id; set => base.Id = value; }

        public List<Message> CreatedMessages { get; set; } = new List<Message>();
        public List<Message> ReceivedMessages { get; set; } = new List<Message>();
    }
}
