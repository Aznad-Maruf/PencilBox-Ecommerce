using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.BLL.Abstructions.Base;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;

namespace Ecommerce.BLL.Abstructions
{
    public interface ICustomerManager : IManager<Customer>
    {
        ICollection<Customer> GetByRequest(CustomerRequestModel customer);
    }
}
