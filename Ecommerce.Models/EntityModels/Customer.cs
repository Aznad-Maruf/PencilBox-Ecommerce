using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Ecommerce.Models.Contracts;

namespace Ecommerce.Models.EntityModels
{
    public class Customer: Ideletable
    {
        public Customer()
        {
            IsDeleted = false;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped]
        public ICollection<Customer> Customers { get; set; }

        public bool Delete()
        {
            IsDeleted = true;
            return true;
        }
    }
}
