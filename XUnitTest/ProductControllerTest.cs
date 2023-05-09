using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Controllers;
using UnitOfWorkDemo.Services.Interfaces;
using Moq;
using UnitOfWorkDemo.Core.Models;

namespace XUnitTest
{
   
    public class ProductControllerTest
    {

        private readonly ProductController _productController;

        public ProductControllerTest()
        {
            var productService = new Mock<IProductService>();
            _productController = new ProductController(productService.Object);
        }

        [Fact]
        public async void Get_product_ReturnsOkResult()
        {
            // Act
            var okResult = await _productController.GetProductList();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        
        [Fact]
        public async void Get_productById_ReturnsOkResult()
        {
            //Arrange
            int productId = 1;
            // Act
            var okResult = await _productController.GetProductById(productId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
           // Assert.IsType<NotFoundObjectResult>(okResult as NotFoundObjectResult);
        }
        
        
        [Fact]
        public async void Get_Created_ReturnsOkResult()
        {
            //Arrange
            var product = new ProductDetails()
            {
                ProductName = "Pop",
                ProductDescription = "black and chilled",
                ProductPrice = 7.00M,
                ProductStock = 3
            };
            // Act
            var okResult = await _productController.CreateProduct(product);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        
    }
}
