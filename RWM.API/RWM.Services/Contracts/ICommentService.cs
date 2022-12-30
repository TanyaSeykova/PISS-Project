using RWM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWM.Services.Contracts
{
    public interface ICommentService
    {
        Task<Comment> GetComment(Guid id);
        Task<Comment> AddComment(Comment comment);

    }
}
