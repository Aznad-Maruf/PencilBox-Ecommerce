using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Models.EntityModels
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }

        [Display(Name = "User Name"), Required]
        public string UserName { get; set; }

        [Required, MaxLength(20, ErrorMessage = "Password Max length is 20"), MinLength(3, ErrorMessage = "Password Min length is 3")]
        public string Password { get; set; }
    }
}
