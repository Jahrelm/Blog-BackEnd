using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Management.Models;

namespace Blog_Management.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetAllBlogAsync();
        Task<BlogPost> GetBlogByIdAsync (int id);
        Task AddBlogAsync(BlogPost blogPost);
        Task UpdateBlogAsync(BlogPost blogPost);
        Task DeleteBlogAsync(int id);

        Task<bool> BlogExists(int id);

    }
}