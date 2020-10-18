using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.Models
{
    public class RandomModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
