using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;

namespace Ecommerce.API.AutomapperProfiles
{
    public class EcommerceApiAutomapperProfiles:Profile
    {
        public EcommerceApiAutomapperProfiles()
        {
            CreateMap<Customer, CustomerCreateDTO>();
            CreateMap<CustomerCreateDTO, Customer>();
        }

    }
}
