using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Management.Dtos;
using Blog_Management.Models;

namespace Blog_Management.Mappers
{
    public static class CommentMapper
    {
            // Maps a Comment model to a CommentDto
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                BlogPostId = commentModel.BlogPostId
            };
        }
             
        // Maps a CreateCommentDto to a Comment model
        
        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int blogId)
        {
            return new Comment
            {
           
                Content = commentDto.Content,
                BlogPostId = blogId,
                CreatedOn = DateTime.UtcNow
             
            };
        }
    }
}