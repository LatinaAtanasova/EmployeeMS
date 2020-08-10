using EMS.Data.Entities;
using EMS.Data.Repository;
using EMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMS.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _repository;

        public DepartmentService(IRepository<Department> repository)
        {
            _repository = repository;
        }

        public string GetDepartmentName(int id)
        {
            return _repository.GetAll().FirstOrDefault(x => x.Id == id).Description;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _repository.GetAll().Where(x => x.isActive).ToList();
        }
    }
}
