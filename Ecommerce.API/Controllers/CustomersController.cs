using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.BLL;
using Ecommerce.BLL.Abstructions;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;
        private readonly IMapper _mapper;
        public CustomersController(ICustomerManager customerManager, IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomers([FromQuery]CustomerRequestModel customer)
        {
            var result = _customerManager.GetByRequest(customer);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id Must Be Positive");
            }
            var customer = _customerManager.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerCreateDTO customerCreateDTO)
        {
            if (ModelState.IsValid)
            {
                // map to customer
                var customer = _mapper.Map<Customer>(customerCreateDTO);
                bool isSaved = _customerManager.Add(customer);
                customerCreateDTO.Id = customer.Id;
                if (isSaved)
                {
                    return CreatedAtRoute("GetCustomer", new {id = customer.Id}, customerCreateDTO);
                }

                return BadRequest(ModelState);

            }

            return BadRequest(ModelState);
        }

        // api/customers/12
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, [FromBody] CustomerCreateDTO customerCreateDto)
        {
            var customer = _customerManager.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }

            //var newCustomer = _mapper.Map<Customer>(customerCreateDto);
            var newCustomer = _mapper.Map(customerCreateDto, customer);
            newCustomer.Id = id;
            bool isUpdated = _customerManager.Update(newCustomer);
            if (isUpdated)
            {
                return Ok(newCustomer);
            }

            return BadRequest("Update Failed");

        }
    }
}