using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.Comment
{
    public class CreateCommentDTO
    {
        [Required(ErrorMessage = "Title is required!")]
        [MinLength(5, ErrorMessage = "Minimum character length is 5!")]
        [MaxLength(280, ErrorMessage = "Maximum character length is 280!")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Content is required!")]
        [MinLength(5, ErrorMessage = "Minimum character length is 5!")]
        [MaxLength(280, ErrorMessage = "Maximum character length is 280!")]
        public string Content { get; set; } = string.Empty;
    }
}