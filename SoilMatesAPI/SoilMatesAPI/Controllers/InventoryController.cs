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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly IInventoryMapper _mapper;

        public InventoryController(IInventoryService inventoryService, IInventoryMapper mapper)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        [HttpGet("get/{pid}/{sid}")]
        [Produces("application/json")]
        public IActionResult GetInventoryItem(int pid, int sid)
        {
            try
            {
                InventoryResource lineItem = _mapper.ParseInventory(_inventoryService.GetInventoryItem(pid, sid));
                return Ok(lineItem);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
