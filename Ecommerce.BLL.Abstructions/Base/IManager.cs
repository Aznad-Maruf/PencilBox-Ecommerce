using System.Collections.Generic;

namespace Ecommerce.BLL.Abstructions.Base
{
    public interface IManager<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        T GetById(int id);
        ICollection<T> GetAll();
    }
}
