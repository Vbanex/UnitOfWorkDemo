using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;
using UnitOfWorkDemo.Core.Models;
using UnitOfWorkDemo.Services.Interfaces;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService) {
        _productService = productService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProductList()
        {
           var productList = await _productService.GetAllProducts();
            if(productList == null)
            {
                return NotFound();
            }
                return Ok(productList);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var product = await _productService.GetProductById(productId);
            if(product == null)
            {
                return NotFound();
            }
                return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDetails productDetails)
        {
            if(productDetails == null)
            {
                return BadRequest();
            }
            var created = await _productService.CreateProduct(productDetails);
            if (created)
            {
                return Ok(created);
            }
                return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDetails productDetails)
        {
            if(productDetails == null)
            {
                return BadRequest();
            }
            var isUpdated = await _productService.UpdateProduct(productDetails);
            if (isUpdated)
            {
                return Ok(isUpdated);
            }
                return BadRequest();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            if(productId == 0)
            {
                return BadRequest();
            }
            var isDeleted = await _productService.DeleteProduct(productId);

            if (isDeleted)
            {
                return Ok(isDeleted);
            }
            return BadRequest();
        }


    

    }
}
