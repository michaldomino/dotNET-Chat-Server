using System;
using dotNET_Chat_Server.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotNET_Chat_Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ApplicationUserChat> ApplicationUserChats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasKey(a => a.Id);

            builder.Entity<Message>()
                .HasOne(m => m.Author)
                .WithMany(a => a.CreatedMessages)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUserChat>().HasKey(it => new { it.ApplicationUserId, it.ChatId });

            builder.Entity<ApplicationUserChat>()
                .HasOne(it => it.ApplicationUser)
                .WithMany(it => it.ApplicationUserChats)
                .HasForeignKey(it => it.ApplicationUserId);

            builder.Entity<ApplicationUserChat>()
                .HasOne(it => it.Chat)
                .WithMany(it => it.ApplicationUserChats)
                .HasForeignKey(it => it.ChatId);

            base.OnModelCreating(builder);
        }
    }
}
