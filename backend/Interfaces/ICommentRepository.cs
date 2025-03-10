using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTOs.Comment;
using backend.Models;

namespace backend.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment comment);  
        Task<Comment?> UpdateAsync(int id, UpdateCommentDTO updateDTO);
        Task<Comment?> DeleteAsync(int id);
    }
}