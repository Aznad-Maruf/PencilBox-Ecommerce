using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EcommerceApp.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; } = false;
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public string Category { get; set; }
        public ICollection<SelectListItem> CategorySelectListItems { get; set; }
    }
}
