using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog_Management.Models;
using Blog_Management.Interfaces;
using Blog_Management.Repositories;

namespace Blog_Management.Controllers
{
    [ApiController]
    [Route("api/BlogPost")]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepo;

        public BlogPostController(IBlogPostRepository blogPostRepo)
        {
            _blogPostRepo = blogPostRepo;
        }

        // GET: api/BlogPost
        [HttpGet("list")]
        public async Task<ActionResult<List<BlogPost>>> GetPosts()
        {
            var posts = await _blogPostRepo.GetAllBlogAsync();
            return Ok(posts);
        }

        // GET: api/BlogPost/GetPostById/{id}
        [HttpGet("GetPostById/{id}")]
        public async Task<ActionResult<BlogPost>> GetPost(int id)
        {
            var post = await _blogPostRepo.GetBlogByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        // POST: api/BlogPost/Add-Post
        [HttpPost("Add-Post")]
        public async Task<ActionResult<BlogPost>> AddPost(BlogPost blogPost)
        {
            await _blogPostRepo.AddBlogAsync(blogPost);
            return CreatedAtAction(nameof(GetPost), new { id = blogPost.Id }, blogPost);
        }

        // PUT: api/BlogPost/UpdatePost/{id}
        [HttpPut("UpdatePost/{id}")]
        public async Task<IActionResult> UpdatePost(int id, BlogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return BadRequest();
            }
            await _blogPostRepo.UpdateBlogAsync(blogPost);
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
