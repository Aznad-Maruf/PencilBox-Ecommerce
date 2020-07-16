using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.BLL.Abstructions;
using Ecommerce.Models.EntityModels;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcommerceApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;
        public ProductController(IProductManager productManager, ICategoryManager categoryManager, IMapper mapper)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryManager.GetAll().ToList();
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Name.ToString(),
                Value = c.Id.ToString()
            }).ToList();
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            Product product = _mapper.Map<Product>(productViewModel);

            if (ModelState.IsValid)
            {
                if (_productManager.Add(product))
                {
                    return RedirectToAction("List");
                }
            }
            return null;
        }

        [HttpGet]
        public IActionResult List()
        {
            List<Product> products = _productManager.GetAll().ToList();
            List<ProductViewModel> products_view_model = products.Select(c=> new ProductViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                Price = c.Price,
                Category = c.Category.Name,
                CategoryId = c.Category.Id
            }).ToList();
            return View(products_view_model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id >= 0)
            {
                var product = _productManager.GetById((int)id);
                var productViewModel = _mapper.Map<ProductViewModel>(product);
                productViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
                return View(productViewModel);
            }

            return RedirectToAction("List");

        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            var product = new Product()
            {
                Id = productViewModel.Id,
                CategoryId = productViewModel.CategoryId,
                Name = productViewModel.Name,
                Code = productViewModel.Code,
                Price = productViewModel.Price,
                IsDeleted = productViewModel.IsDeleted
            };
            _productManager.Update(product);
            return RedirectToAction("List");
        }


        public IActionResult Delete(int id)
        {
            if(id> 0)
            {
                var product = _productManager.GetById(id);
                _productManager.Remove(product);
            }
            
            return RedirectToAction("List");
        }
    }
}