using Inventory.Application.Interfaces;
using Inventory.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProductWithStatus")]
        public IActionResult GetAllProductWithStatus()
        {
           var response =  _productService.CountOfAllProductStatus();

            //Create a return type for all endpoints
            return Ok(response);
        }

        [HttpGet("ChangeProductStatusByProductName")]
        public async Task<IActionResult> ChangeProductStatusByProductName(string productName, string status)
        {
             await _productService.ChangeProductStatusByProductName(productName, status);

            //Create a return type for all endpoints
            return Ok();
        }

        [HttpGet("BuyProductByName")]
        public async  Task<IActionResult> BuyProductByName(string productName)
        {
           await _productService.BuyProductByProductName(productName);

            //Create a return type for all endpoints
            return Ok();
        }
    }
}
