using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;
using Ecommerce.Repositories.Abstructions;
using Ecommerce.Repositories.Abstructions.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class CustomerRepository:Repository<Customer>, ICustomerRepository
    {
        private readonly EcommerceDbContext _dbContext;
        public CustomerRepository(DbContext db) : base(db)
        {
            _dbContext = (EcommerceDbContext)db;
        }

        //public bool Add(Customer entity)
        //{
        //    _dbContext.Customers.Add(entity);
        //    return _dbContext.SaveChanges() > 0;
        //}

        //public bool Update(Customer entity)
        //{
        //    _dbContext.Entry(entity).State = EntityState.Modified;
        //    return _dbContext.SaveChanges() > 0;

        //}

        public override ICollection<Customer> GetAll()
        {
            return _dbContext.Customers.Where(c => c.IsDeleted == false).ToList();
        }

        public ICollection<Customer> GetByRequest(CustomerRequestModel customer)
        {
            var customers = _dbContext.Customers.AsQueryable();
            if (customer == null) return customers.ToList();
            if (customer.Id > 0) customers = customers.Where(c => c.Id == customer.Id);
            if (!String.IsNullOrEmpty(customer.Name))
                customers = customers.Where(c => c.Name.ToLower().Contains(customer.Name.ToLower()));
            if (!String.IsNullOrEmpty(customer.Address))
                customers = customers.Where(c => c.Address.ToLower().Contains(customer.Address.ToLower()));
            if (!String.IsNullOrEmpty(customer.Phone))
                customers = customers.Where(c => c.Phone.ToLower().Equals(customer.Phone.ToLower()));
            if (customer.IsDeleted != null)
                customers = customers.Where(c=>c.IsDeleted == customer.IsDeleted);

            return customers.ToList();

        }

        //public bool Remove(Customer entity)
        //{
        //    entity.IsDeleted = true;
        //    return Update(entity);
        //}

        public Customer GetById(int id)
        {
            return base.GetFirstOrDefault(c => c.Id == id);
        }
    }
}
