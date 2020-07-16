using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.BLL.Abstructions;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Abstructions;

namespace Ecommerce.BLL
{
    public class CustomerManager:ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public bool Add(Customer entity)
        {
            // check for all conditions and validations before adding.
            if (string.IsNullOrEmpty(entity.Name))
            {
                return false;
            }
            return _customerRepository.Add(entity);
        }

        public bool Update(Customer entity)
        {
            return _customerRepository.Update(entity);
        }

        public bool Remove(Customer entity)
        {
            return _customerRepository.Remove(entity);
        }

        public ICollection<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public ICollection<Customer> GetByRequest(CustomerRequestModel customer)
        {
            return _customerRepository.GetByRequest(customer);
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }
    }
}
