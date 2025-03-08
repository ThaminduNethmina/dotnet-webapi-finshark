using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.Comment;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDTOs = comments.Select(c => c.ToCommentDTO()).ToList();

            return Ok(commentDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null) 
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDTO());
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDTO createDTO)
        {
            if (!await _stockRepository.IsStockExist(stockId))
            {
                return BadRequest("Stock does not exist");
            }
            
            var comment = createDTO.ToCommentFromCreateDTO(stockId);
            await _commentRepository.CreateAsync(comment);

            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.ToCommentDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDTO updateDTO)
        {
            var comment = await _commentRepository.UpdateAsync(id, updateDTO);

            if (comment == null)
                return NotFound();
                
            return Ok(comment.ToCommentDTO());
        }
    }
}