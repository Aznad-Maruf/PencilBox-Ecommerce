using System.Collections.Generic;
using System.Linq;
using Ecommerce.Repositories.Abstructions.Base;

namespace Ecommerce.BLL.Abstructions.Base
{
    public abstract class Manager<T, TU> : IManager<T> 
        where T: class 
        where TU:IRepository<T>
    {
        //private readonly T _model;
        private readonly TU _repository;
        

        protected Manager( TU repository)
        {
            _repository = repository;
        }

        public bool Add(T entity)
        {
            return _repository.Add(entity);
        }

        public bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        public bool Remove(T entity)
        {
            return _repository.Remove(entity);
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public ICollection<T> GetAll()
        {
            return _repository.GetAll();
        }
    }

}
