using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstructions;
using Ecommerce.Repositories.Abstructions.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class AdminRepository:Repository<Admin>, IAdminRepository
    {
        public AdminRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
