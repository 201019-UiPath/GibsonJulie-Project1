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
    /// API controller for Manager services
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly IManagerMapper _mapper;

        public ManagerController(IManagerService managerService, IManagerMapper mapper)
        {
            _managerService = managerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all managers
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllManagers()
        {
            try
            {
                return Ok(_mapper.ParseManager(_managerService.GetAllManagers()));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets manager by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>JSON of manager</returns>
        [HttpGet("get/{email}")]
        [Produces("application/json")]
        public IActionResult GetManagerByEmail(string email)
        {
            try
            {
                ManagerResource manager = _mapper.ParseManager(_managerService.GetManagerByEmail(email));
                return Ok(manager);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Creates manager 
        /// </summary>
        /// <param name="newManager"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddManager(ManagerResource newManager)
        {
            try
            {
                _managerService.AddManager(_mapper.ParseManager(newManager));
                _managerService.SaveChanges();
                return CreatedAtAction("AddCustomer", newManager);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}


