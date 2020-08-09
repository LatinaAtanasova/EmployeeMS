using EMS.Data.Entities;
using EMS.Data.Repository;
using EMS.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _repository;

        public CommentService(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public int Add(Comment comment)
        {
            return _repository.Insert(comment);
        }

        public void Update(Comment comment)
        {
            _repository.Update(comment);
        }

        public IEnumerable<Comment> GetActiveCommentsByEmployeeId(int id)
        {
            return _repository.GetAll().Where(x => x.EmployeeId == id && !x.isDeleted).ToList();
        }

        public Comment GetCommentById(int id)
        {
            return _repository.GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
