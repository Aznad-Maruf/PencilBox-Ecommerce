using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Ecommerce.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ecommerce.Repositories.Abstructions.Base
{
    public abstract class Repository<T> where T:class
    {
        private readonly DbContext _dbContext;
        private DbSet<T> Table => _dbContext.Set<T>();

        protected Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(T entity)
        {
            Table.Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool Remove(T entity)
        {
            if (entity is Ideletable deletable)
            {
                deletable.Delete();
                return Update(entity);
            }

            _dbContext.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }

        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public virtual T GetById(int id)
        {
            return Table.Find(id);
        }
    }
}
