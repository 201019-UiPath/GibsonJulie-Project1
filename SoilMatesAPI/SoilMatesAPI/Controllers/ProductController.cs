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
    /// Controller for product models 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductMapper _mapper;

        public ProductController(IProductService productService, IProductMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all products 
        /// </summary>
        /// <returns>JSON of Product resources</returns>
        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(_mapper.ParseProduct(_productService.GetAllProducts()));
            } catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets products by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns product</returns>
        [HttpGet("get/id/{id}")]
        [Produces("application/json")]
        public IActionResult GetProductById(int id){
            try
            {
                return Ok(_mapper.ParseProduct(_productService.GetProduct(id)));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// gets product by name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>JSON product</returns>
        [HttpGet("get/name/{name}")]
        [Produces("application/json")]
        public IActionResult GetProductByName(String name)
        {
            try
            {
                return Ok(_mapper.ParseProduct(_productService.GetProduct(name)));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Adds product
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [HttpPost("add/{name}/{price}/{description}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public IActionResult AddProduct(string name, decimal price, string description)
        {
            try
            {
                _productService.AddNewProduct(name, price, description);
                _productService.SaveChanges();
                ProductResource newProduct = new ProductResource
                {
                    Description = description,
                    Name = name,
                    Price = price,
                };
                return CreatedAtAction("addProduct", newProduct);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
