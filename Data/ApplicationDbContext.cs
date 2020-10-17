using System;
using System.Collections.Generic;
using System.Text;
using dotNET_Chat_Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotNET_Chat_Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>(this));
            ApplicationUser user1 = new ApplicationUser();
            ApplicationUser user2 = new ApplicationUser();
            Message message = new Message()
            {
                Author = user1,
                Recipient = user2,
                Text = "abc",
                CreationTime = DateTime.Now,
            };

            builder.Entity<ApplicationUser>().HasData(user1);
            builder.Entity<ApplicationUser>().HasData(user2);
            builder.Entity<Message>().HasData(message);

            base.OnModelCreating(builder);
        }
    }
}
