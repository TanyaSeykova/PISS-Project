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
        Comment GetComment(Guid id);
        List<Comment> GetAllComments();
        Comment AddComment(Comment comment);

    }
}
