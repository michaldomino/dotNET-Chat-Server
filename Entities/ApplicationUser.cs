using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNET_Chat_Server.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            CreatedMessages = new HashSet<Message>();
            ApplicationUserChats = new HashSet<ApplicationUserChat>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get => base.Id; set => base.Id = value; }

        public virtual ICollection<Message> CreatedMessages { get; set; }

        public virtual ICollection<ApplicationUserChat> ApplicationUserChats { get; set; }
    }
}
