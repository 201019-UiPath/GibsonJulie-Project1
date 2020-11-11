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
    [Route("/[controller]")]
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
    }
}
