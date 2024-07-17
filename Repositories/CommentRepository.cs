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

        //get comment by postId

         public async Task<List<Comment>> GetPostComments(int postId)
        {
           var comments =  _dbContext.Comments
            .Where(c => c.BlogPostId == postId && c.ParentCommentId == null)
            .ToList();

          

           var replies =  _dbContext.Comments
           .Where(c => c.BlogPostId == postId && c.ParentCommentId != null)
           .ToList();

              Console.WriteLine("Replies : "+ replies.Count);

            foreach( var comment in comments){
                comment.Replies = replies.Where(r => r.ParentCommentId == comment.Id)
                .ToList();
            }

           return comments;
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