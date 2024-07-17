using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog_Management.Models;
using Blog_Management.Interfaces;
using Blog_Management.Repositories;
using Blog_Management.Mappers;
using Blog_Management.Dtos;

namespace Blog_Management.Controllers
{
    [ApiController]
    [Route("api/BlogPost")]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepo;
        private readonly ICommentRepository _commentRepo;

        public BlogPostController(IBlogPostRepository blogPostRepo)
        {
            _blogPostRepo = blogPostRepo;
        }

        // GET: api/BlogPost
        [HttpGet("list")]
        public async Task<ActionResult<List<BlogPost>>> GetPosts()
        {
            var posts = await _blogPostRepo.GetAllBlogAsync();
            var postDto = posts.Select(p => p.ToBlogPostDto());

            return Ok(postDto);
        }

        // GET: api/BlogPost/GetPostById/{id}
        [HttpGet("GetPostById/{id}")]
        //separate comments from posts
        public async Task<ActionResult<BlogPost>> GetPost(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var post = await _blogPostRepo.GetBlogByIdAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            //post.Comments = await _commentRepo.GetPostComments(id);
            return Ok(post);
        }

        // POST: api/BlogPost/Add-Post
        [HttpPost("Add-Post")]
        public async Task<ActionResult<BlogPost>> AddPost(CreateBlogPostDto blogPostDto)
        {
            // Convert the CreateBlogPostDto to a BlogPost model
            var blogPost = blogPostDto.ToBlogPost();

            // Add the BlogPost model to the repository
            await _blogPostRepo.AddBlogAsync(blogPost);

            // Convert the BlogPost model to a BlogPostDto
            var createdBlogPostDto = blogPost.ToBlogPostDto();

            // Return the created BlogPostDto with a CreatedAtAction response
            return CreatedAtAction(nameof(GetPost), new { id = createdBlogPostDto.Id }, createdBlogPostDto);
        }

        // PUT: api/BlogPost/UpdatePost/{id}
        [HttpPut("UpdatePost/{id}")]
        public async Task<IActionResult> UpdatePost(int id, BlogPostDto blogPostDto)
        {
            if (id != blogPostDto.Id)
            {
                return BadRequest();
            }

            var blogPostModel = await _blogPostRepo.GetBlogByIdAsync(id);
            if (blogPostModel == null)
            {
                return NotFound();
            }

            // Update properties from DTO to the model
            blogPostModel.Title = blogPostDto.Title;
            blogPostModel.Content = blogPostDto.Content;
            blogPostModel.Category = blogPostDto.Category;
            blogPostModel.UpdatedAt = DateTime.UtcNow;

            await _blogPostRepo.UpdateBlogAsync(blogPostModel);
            return NoContent();
        }

        // DELETE: api/BlogPost/DeleteById/{id}
        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var existingPost = await _blogPostRepo.GetBlogByIdAsync(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            await _blogPostRepo.DeleteBlogAsync(id);
            return NoContent();
        }
    
    }
}
