using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.BLL.Abstructions;
using Ecommerce.BLL.Abstructions.Base;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Abstructions;

namespace Ecommerce.BLL
{
    public class ProductManager : Manager<Product, IProductRepository>, IProductManager
    {
        public ProductManager(IProductRepository repository) : base(repository)
        {
        }
    }
}
