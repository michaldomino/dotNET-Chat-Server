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
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<RandomModel> RandomModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasKey(a => a.Id);

            builder.Entity<Message>()
                .HasOne(m => m.Author)
                .WithMany(a => a.CreatedMessages)
                .OnDelete(DeleteBehavior.Cascade);

            RandomModel randomModel = new RandomModel()
            {
                Id = Guid.NewGuid(),
                Name = "a",
                Number = 5,
            };
            builder.Entity<RandomModel>().HasData(randomModel);


            //builder.Entity<Message>()
            //    .HasOne(m => m.Recipient)
            //    .WithMany(r => r.ReceivedMessages)
            //    .OnDelete(DeleteBehavior.SetNull);

            //UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>(this));
            //UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>(this));
            //ApplicationUser user1 = new ApplicationUser()
            //{
            //    UserName = "Abc",
            //    Email = "abc@def.com"
            //};
            //userManager.CreateAsync(user1, "abc");



            //ApplicationUser user2 = new ApplicationUser()
            //{
            //    Id = Guid.NewGuid(),
            //};
            //Message message = new Message()
            //{
            //    Id = Guid.NewGuid(),
            //    AuthorId = user1.Id,
            //    RecipientId = user2.Id,
            //    Text = "abc",
            //    CreationTime = DateTime.Now,
            //};

            //builder.Entity<ApplicationUser>().HasData(user1);
            //builder.Entity<ApplicationUser>().HasData(user2);
            //builder.Entity<Message>().HasData(message);

            base.OnModelCreating(builder);
        }
    }
}
