using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Models.EntityModels;

namespace EcommerceApp.Models
{
    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
