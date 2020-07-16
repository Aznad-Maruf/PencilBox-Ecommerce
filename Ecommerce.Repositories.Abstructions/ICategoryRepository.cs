using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstructions.Base;

namespace Ecommerce.Repositories.Abstructions
{
    public interface ICategoryRepository:IRepository<Category>
    {
    }
}
