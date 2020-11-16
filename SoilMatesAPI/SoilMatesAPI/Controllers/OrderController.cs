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
    /// API to controller for order operations 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderMapper _mapper;

        public OrderController(IOrderService orderService, IOrderMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all orders by 
        /// </summary>
        /// <returns>List of orders</returns>
        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllOrders()
        {
            try
            {
                return Ok(_mapper.ParseOrder( _orderService.GetAllOrders()));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets order by customer id, sorted order is preset to order by price
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sortType"></param>
        /// <returns></returns>
        [HttpGet("get/Customer/{id}/{sortType=0}")]
        [Produces("application/json")]
        public IActionResult GetOrderByCustomerId(string id, int sortType)
        {
           List<OrderResource> order = _mapper.ParseOrder(_orderService.GetOrderByCustomerId(id));
            
            try
            {
                if (sortType == 0)
                {
                    order.Sort((x, y) => Decimal.Compare(x.TotalPrice, y.TotalPrice));
                }
                else if (sortType == 1)
                {
                    order.Sort((x, y) => DateTime.Compare(y.OrderTime, x.OrderTime));
                }
                return Ok(order);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Returns order by location id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get/Location/{id}")]
        [Produces("application/json")]
        public IActionResult GetOrderByLocationId(int id)
        {
            List<OrderResource> order = _mapper.ParseOrder(_orderService.GetOrderByLocatoinId(id));
            try
            {
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// adds complete order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult AddOrder(OrderResource order)
        {
            try
            {
                _orderService.AddOrder(_mapper.ParseOrder(order));
                _orderService.SaveChanges();
                return CreatedAtAction("addOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// adds complete order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost("add/new")]
        [Produces("application/json")]
        public IActionResult NewOrder( )
        {
            try
            {
                Order newOrder = new Order();
                return CreatedAtAction("addOrder", newOrder);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
