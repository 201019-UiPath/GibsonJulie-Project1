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
using Serilog;

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

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetInventoryItem()
        {
            try
            {
                var allInventory =_mapper.ParseInventory(_inventoryService.GetAllInventory());
                return Ok(allInventory);
            }
            catch (Exception)
            {
                Log.Warning("Inventory item access failed");
                return BadRequest();
            }
        }

        [HttpGet("get/{productId}/{locationId}")]
        [Produces("application/json")]
        public IActionResult GetInventoryItem(int productId, int locationId)
        {
            try
            {
                InventoryResource all = _mapper.ParseInventory(_inventoryService.GetInventoryItem(productId, locationId));

                //var all =_mapper.ParseInventory(_inventoryService.GetAllInventory());
                return Ok(all);
            }
            catch (Exception)
            {
                Log.Warning("Inventory item access failed");
                return BadRequest();
            }
        }

        [HttpPut("put/{productId}/{locationId}/{quantity}")]
        [Produces("application/json")]
        public IActionResult UpdateInventoryItem(int productId, int locationId, int quantity)
        {
            try
            {
                Log.Information("Updated inventory item");
                Inventory lineItem = _inventoryService.GetInventoryItem(productId, locationId);
                if(quantity > 0)
                {
                    lineItem.Quantity += quantity;
                }
                _inventoryService.SaveChanges();
                return Ok(_mapper.ParseInventory(lineItem));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
