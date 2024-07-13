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
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _dbContext;

        public CommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public async Task<List<Comment>> GetAllAsync()
        {
           return await _dbContext.Comments
           .Include(c => c.Replies)
           .ToListAsync();

        }

        public async Task<Comment> CreateAsync(Comment commentModel){
            await _dbContext.Comments.AddAsync(commentModel);
            await _dbContext.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
           var comment = await _dbContext.Comments
            .Include(c => c.Replies)
            .FirstOrDefaultAsync(c => c.Id == id);
           return comment;
        }
    }
}