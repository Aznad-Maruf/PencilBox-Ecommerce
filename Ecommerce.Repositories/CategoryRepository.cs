using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstructions;
using Ecommerce.Repositories.Abstructions.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
