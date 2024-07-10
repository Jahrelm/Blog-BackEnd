using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Management.Dtos;
using Blog_Management.Models;

namespace Blog_Management.Mappers
{
    public static class BlogPostMapper
    {
        // Maps a BlogPost model to a BlogPostDto
        public static BlogPostDto ToBlogPostDto(this BlogPost blogPost)
        {
            return new BlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                Category = blogPost.Category,
                CreatedAt = blogPost.CreatedAt,
                UpdatedAt = blogPost.UpdatedAt,
                Comments = blogPost.Comments.Select(c => c.ToCommentDto()).ToList()

            };
            
        }
        // Maps a CreateBlogPostDto to a BlogPost model
        public static BlogPost ToBlogPost(this CreateBlogPostDto blogPostDto)
        {
            return new BlogPost
            {
                Title = blogPostDto.Title,
                Content = blogPostDto.Content,
                Category = blogPostDto.Category,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        
        }
    }
}