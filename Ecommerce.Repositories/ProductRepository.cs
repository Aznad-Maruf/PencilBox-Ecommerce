using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstructions;
using Ecommerce.Repositories.Abstructions.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private EcommerceDbContext _db;
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
            _db = (EcommerceDbContext)dbContext;
        }

        public Product GetById(int id)
        {
            return base.GetFirstOrDefault(c => c.Id == id);
        }

        public override ICollection<Product> GetAll()
        {
            return _db.Products.Include( c=>c.Category).Where(c => c.IsDeleted == false).ToList();
        }
    }
}
