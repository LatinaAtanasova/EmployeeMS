using EMS.Data.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMS.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly EMSDbContext _context;
        private DbSet<T> entities;

        public Repository(EMSDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsNoTracking().AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public int Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                entities.Add(entity);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return entity.Id;
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _context.Update(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
