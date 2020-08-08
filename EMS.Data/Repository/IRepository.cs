using EMS.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        //void Insert(IEnumerable<T> entityCollection);
        void Update(T entity);
        //void Update(IEnumerable<T> entityCollection);
    }
}
