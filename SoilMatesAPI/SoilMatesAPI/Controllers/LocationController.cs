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
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ILocationMapper _mapper;
        
        public LocationController(ILocationService locationService, ILocationMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllLocations()
        {
            try 
            {
                return Ok(_mapper.ParseLocation(_locationService.GetAllLocations()));
            } 
            catch(Exception) 
            {
                return BadRequest();
            }

        }

        [HttpGet("get/{id}")]
        [Produces("application/json")]
        public IActionResult GetLocationById(int id)
        {
            try
            {
                return Ok(_mapper.ParseLocation(_locationService.GetLocationById(id)));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("add")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult AddLocation(LocationResource location)
        {
            try
            {
                _locationService.AddLocation(_mapper.ParseLocation(location));
                _locationService.SaveChanges();
                return CreatedAtAction("AddLocation", location);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
