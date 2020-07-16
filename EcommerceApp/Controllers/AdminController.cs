using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.BLL.Abstructions;
using Ecommerce.Models.EntityModels;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAdminManager _adminManager;
        private readonly IMapper _mapper;

        public AdminController(IAdminManager adminManager, IMapper mapper)
        {
            _adminManager = adminManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            AdminViewModel adminViewModel = new AdminViewModel();

            return View(adminViewModel);
        }

        [HttpPost]
        public IActionResult Create(AdminViewModel adminViewModel)
        {
            var admin = _mapper.Map<Admin>(adminViewModel);

            if (ModelState.IsValid)
            {
                if (_adminManager.Add(admin))
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("Create");
        }

        [HttpGet]
        public IActionResult List()
        {
            var adminViewModels = _adminManager.GetAll().Select(c => _mapper.Map<AdminViewModel>(c)).ToList();
            return View(adminViewModels);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id >= 0)
            {
                var admin = _adminManager.GetById(id);
                var adminViewModel = _mapper.Map<AdminViewModel>(admin);

                return View(adminViewModel);
            }

            return RedirectToAction("List");

        }

        [HttpPost]
        public IActionResult Edit(AdminViewModel adminViewModel)
        {
            var admin = _mapper.Map<Admin>(adminViewModel);
            _adminManager.Update(admin);
            return RedirectToAction("List");
        }


        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var admin = _adminManager.GetById(id);
                _adminManager.Remove(admin);
            }

            return RedirectToAction("List");
        }
    }
}