using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_Management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

        }
        public DbSet<BlogPost> BlogPosts {get; set;}
        
    }
}