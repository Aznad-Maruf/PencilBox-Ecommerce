using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.BLL.Abstructions;
using Ecommerce.BLL.Abstructions.Base;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstructions;

namespace Ecommerce.BLL
{
    public class AdminManager:Manager<Admin, IAdminRepository>, IAdminManager
    {
        public AdminManager(IAdminRepository repository) : base(repository)
        {
        }
    }
}
