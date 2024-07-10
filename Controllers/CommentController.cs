using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Management.Dtos;
using Blog_Management.Interfaces;
using Blog_Management.Mappers;
using Blog_Management.Models;
using Blog_Management.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Management.Controllers
{
    [ApiController]
    [Route("api/Comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IBlogPostRepository _blogPostRepo;

        public CommentController(ICommentRepository commentRepository, IBlogPostRepository blogPostRepo ){

            _commentRepository = commentRepository;
            _blogPostRepo =  blogPostRepo;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var comments = await _commentRepository.GetAllAsync();
            
            var commentDto = comments.Select(s => s.ToCommentDto());
            
            return Ok(commentDto);
         
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }
        [HttpPost("{blogId}")]
        public async Task<IActionResult> Create([FromRoute] int blogId, CreateCommentDto commentDto)
        {
            if(!await _blogPostRepo.BlogExists(blogId)){
                return BadRequest("Blog does not exist");
            }

            var commentModel = commentDto.ToCommentFromCreate(blogId);
            await _commentRepository.CreateAsync(commentModel);

            

            return CreatedAtAction(nameof(GetById), new { id = commentModel }, commentModel.ToCommentDto());

        }
        
    }
}