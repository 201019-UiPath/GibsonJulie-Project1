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
    /// <summary>
    /// Controller that handles Inventory items
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly IInventoryMapper _mapper;

        /// <summary>
        /// Inventory constructor with mapper and inventory service dependancy injection
        /// </summary>
        /// <param name="inventoryService"></param>
        /// <param name="mapper"></param>
        public InventoryController(IInventoryService inventoryService, IInventoryMapper mapper)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
        }


        /// <summary>
        /// Gets all inventory items 
        /// </summary>
        /// <returns>List<InventoryResource></returns>
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

        /// <summary>
        /// Gets inventory by product id and location id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="locationId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// updates inventory quantity given location and product ids
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="locationId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add inventory product 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="locationId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpPost("add/{productId}/{locationId}/{quantity}")]
        [Produces("application/json")]
        public IActionResult AddInventoryItem(int productId, int locationId, int quantity)
        {
            try
            {
                _inventoryService.AddItemToInventory(productId, locationId, quantity);
                Log.Information("Added Inventory Item");
                return Ok();
            }
            catch (Exception e)
            {
                Log.Warning(e.Message);
                return BadRequest();
            }
        }
    }
}
