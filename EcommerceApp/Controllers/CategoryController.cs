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
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryManager categoryManager, IMapper mapper)
        {
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
            CategoryViewModel categoryViewModel = new CategoryViewModel();

            return View(categoryViewModel);
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel categoryViewModel)
        {
            Category category = _mapper.Map<Category>(categoryViewModel);

            if (ModelState.IsValid)
            {
                if (_categoryManager.Add(category))
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("Create");
        }

        [HttpGet]
        public IActionResult List()
        {
            var categoriesViewModel = _categoryManager.GetAll().Select(c => _mapper.Map<CategoryViewModel>(c)).ToList();
            return View(categoriesViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id >= 0)
            {
                var category = _categoryManager.GetById(id);
                var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
                
                return View(categoryViewModel);
            }

            return RedirectToAction("List");

        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            _categoryManager.Update(category);
            return RedirectToAction("List");
        }


        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var category = _categoryManager.GetById(id);
                _categoryManager.Remove(category);
            }

            return RedirectToAction("List");
        }

    }
}