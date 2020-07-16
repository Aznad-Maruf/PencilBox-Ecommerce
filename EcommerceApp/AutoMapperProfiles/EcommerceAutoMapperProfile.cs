using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Models.EntityModels;
using EcommerceApp.Models;

namespace EcommerceApp.AutoMapperProfiles
{
    public class EcommerceAutoMapperProfile:Profile
    {
        public EcommerceAutoMapperProfile()
        {
            CreateMap<Admin, AdminViewModel>();
            CreateMap<AdminViewModel, Admin>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}
