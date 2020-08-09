using EMS.Data.Entities;
using System.Collections.Generic;

namespace EMS.Services.Interfaces
{
    public interface ICommentService
    {
        int Add(Comment comment);
        IEnumerable<Comment> GetActiveCommentsByEmployeeId(int id);
        void Update(Comment comment);
        Comment GetCommentById(int id);
    }
}
