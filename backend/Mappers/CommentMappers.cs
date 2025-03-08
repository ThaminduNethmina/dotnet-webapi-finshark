using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.Comment;
using backend.Models;

namespace backend.Mappers
{
    public static class CommentMappers
    {
        public static CommentDTO ToCommentDTO(this Comment comment)
        {
            return new CommentDTO 
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId
            };
        }

        public static Comment ToCommentFromCreateDTO(this CreateCommentDTO comment, int stockId)
        {
            return new Comment 
            {
                Title = comment.Title,
                Content = comment.Content,
                StockId = stockId
            };
        }
    }
}