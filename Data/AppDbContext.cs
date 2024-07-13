using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Blog_Management.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

        }
        public DbSet<BlogPost> BlogPosts {get; set;}

        public DbSet<Comment> Comments {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Comment>()
                .HasOne(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId);

            builder.Entity<Comment>()
                .HasOne(c => c.BlogPost)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.BlogPostId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                    
                }, 
                            new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"

                }             
            };
            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<BlogPost>()
            .Property(b => b.Id)
            .ValueGeneratedOnAdd();
        }
  

    }
}