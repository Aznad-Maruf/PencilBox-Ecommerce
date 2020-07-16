using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Ecommerce.Models.Contracts;

namespace Ecommerce.Models.EntityModels
{
    public class Product:Ideletable
    {
        public Product()
        {
            IsDeleted = false;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        public bool Delete()
        {
            IsDeleted = true;
            return true;
        }

        public virtual Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}
