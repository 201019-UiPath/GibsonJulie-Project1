﻿using System;
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

        [HttpGet("get/Customer/{id}")]
        [Produces("application/json")]
        public IActionResult GetOrderByCustomerId(int id)
        {
           List<OrderResource> order = _mapper.ParseOrder(_orderService.GetOrderByCustomerId(id));
            try
            {
                return Ok(order);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

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
    }
}
