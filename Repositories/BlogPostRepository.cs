using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Management.Data;
using Blog_Management.Interfaces;
using Blog_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_Management.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly AppDbContext _dbContext;

        public BlogPostRepository(AppDbContext dbContext){
            _dbContext = dbContext;
        }

        public async Task<List<BlogPost>> GetAllBlogAsync(){
            return await _dbContext.BlogPosts.Include(c => c.Comments).ToListAsync();
        }

        public async Task<BlogPost> GetBlogByIdAsync(int id){
            return await _dbContext.BlogPosts.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddBlogAsync(BlogPost post){
            _dbContext.Add(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateBlogAsync(BlogPost post){
            _dbContext.Entry(post).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBlogAsync(int id){
            var post = await _dbContext.BlogPosts.FindAsync(id);
            if (post != null){
                _dbContext.BlogPosts.Remove(post);
                await _dbContext.SaveChangesAsync();
            }
        }

        public  Task<bool> BlogExists(int id){
            return _dbContext.BlogPosts.AnyAsync(b => b.Id == id);
        }
    }
} 