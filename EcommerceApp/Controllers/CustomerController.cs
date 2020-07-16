using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.BLL;
using Ecommerce.BLL.Abstructions;
using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        private readonly ICustomerManager _customerManager;
        private IMapper _mapper;

        public CustomerController(ICustomerManager customerManager, IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            Customer customer = new Customer()
            {
                Customers = _customerManager.GetAll()
            };
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(CustomerViewModel customerViewModel)
        {
            Customer customer = _mapper.Map<Customer>(customerViewModel);
            if (ModelState.IsValid)
            {
                if (_customerManager.Add(customer))
                {
                    RedirectToAction("List");
                }
            }

            
            customer.Customers = _customerManager.GetAll();
            return View(customer);
        }

        public IActionResult List()
        {
            var customers = _customerManager.GetAll();

            return View(customers);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Customer existingCustomer = _customerManager.GetById((int)id);
                return View("Edit", existingCustomer);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (_customerManager.Update(customer))
                return RedirectToAction("List");

            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var customer = _customerManager.GetById((int) id);
            _customerManager.Remove(customer);
            return RedirectToAction("List");
        }

    }
}
