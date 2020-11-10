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

        [HttpGet("get/{email}")]
        [Produces("application/json")]
        public IActionResult GetCustomerByEmail(string email)
        {
            try
            {
                CustomerWeb customer = _mapper.ParseCustomer(_customerService.GetCustomerByEmail(email));
                return Ok(customer);
            } catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCustomer(CustomerWeb newCustomer)
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
