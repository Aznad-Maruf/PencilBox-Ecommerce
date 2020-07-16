using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;
using Ecommerce.Repositories.Abstructions.Base;

namespace Ecommerce.Repositories.Abstructions
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        ICollection<Customer> GetByRequest(CustomerRequestModel customer);
    }
}
