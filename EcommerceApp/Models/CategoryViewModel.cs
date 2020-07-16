using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models.EntityModels;

namespace EcommerceApp.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required, MinLength(3, ErrorMessage ="Minimum length is 3")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
