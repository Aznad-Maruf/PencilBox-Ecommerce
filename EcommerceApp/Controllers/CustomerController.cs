using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Database;
using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        private EcommerceDbContext ecommerceDbContext = new EcommerceDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            Customer customer = new Customer()
            {
                customers = ecommerceDbContext.Customers.ToList()
            };
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {

            if (ModelState.IsValid)
            {
                ecommerceDbContext.Customers.Add(customer);

                ecommerceDbContext.SaveChanges();
            }

            //if (isSaved) return RedirectToAction("List");
            customer.customers = ecommerceDbContext.Customers.ToList();
            return View(customer);
        }

        public IActionResult List()
        {
            List<Customer> customers = ecommerceDbContext.Customers.ToList();

            return View(customers);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Customer existingCustomer = ecommerceDbContext.Customers.Find(id);
                return View("Edit", existingCustomer);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            ecommerceDbContext.Entry(customer).State = EntityState.Modified;
            if(ecommerceDbContext.SaveChanges()>0)
            return RedirectToAction("List");

            return View(customer);
        }

    }
}
