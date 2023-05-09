namespace TestApi
{
    using UnitOfWorkDemo.Controllers;
    using UnitOfWorkDemo.Services.Interfaces;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
          private static IProductService _productService;
        ProductController productController = new ProductController(_productService);
            Assert.Pass();
        }
    }
}