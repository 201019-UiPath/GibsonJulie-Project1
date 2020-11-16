using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoilMatesLib;
using SoilMatesResources;
using SoilMatesResources.Models;
using SoilMatesDB.Models;

namespace SoilMatesAPI.Controllers
{
    /// <summary>
    /// API Controller for handling customer CRUD opertations
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerMapper _mapper;

        public CustomerController(ICustomerService customerService, ICustomerMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }


        /// <summary>
        /// Gets all customers 
        /// </summary>
        /// <returns>list of JSON customer objects</returns>
        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                return Ok(_mapper.ParseCustomer(_customerService.GetAllCustomers()));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets all customers by email identification 
        /// </summary>
        /// <param name="email"></param>
        /// <returns>JSON Customer</returns>
        [HttpGet("get/{email}")]
        [Produces("application/json")]
        public IActionResult GetCustomerByEmail(string email)
        {
            try
            {
                CustomerResource customer = _mapper.ParseCustomer(_customerService.GetCustomerByEmail(email));
                return Ok(customer);
            } catch (Exception)
            {
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Adds customer 
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns>JSON Customer</returns>
        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCustomer(CustomerResource newCustomer)
        {
            try
            {
                _customerService.AddCustomer(_mapper.ParseCustomer(newCustomer));
                _customerService.SaveChanges();
                return CreatedAtAction("AddCustomer", newCustomer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

       
    }
}
