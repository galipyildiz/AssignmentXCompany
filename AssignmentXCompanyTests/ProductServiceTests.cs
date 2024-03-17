using AssignmentXCompany.Data;
using AssignmentXCompany.Models;
using AssignmentXCompany.Services.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AssignmentXCompanyTests
{
    public class ProductServiceTests
    {
        private DbContextOptions<AppDbContext> _dbContextOptions;
        private AppDbContext _dbContext;
        private ProductFromSQLService _productService;

        [OneTimeSetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: "TestDatabase")
               .Options;

            _dbContext = new AppDbContext(_dbContextOptions);
            _productService = new ProductFromSQLService(_dbContext);

            SeedTestData();
        }

        [Test]
        public async Task GetProducts_ReturnsAllProductsAndCountEqual2()
        {
            var products = await _productService.GetProductsAsync();

            Assert.IsNotNull(products);
            Assert.That(products.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task TryGetProductById_ProductExists_ReturnsProduct()
        {
            int productId = 1;

            var product = await _productService.TryGetProductByIdAsync(productId);

            Assert.IsNotNull(product);
            Assert.That(product.Id, Is.EqualTo(productId));
        }


        [Test]
        public async Task TryGetProductById_ProductDoesNotExists_ReturnsNull()
        {
            int productId = 100;

            var product = await _productService.TryGetProductByIdAsync(productId);

            Assert.IsNull(product);
        }

        [Test]
        public async Task TryAddProduct_ValidProduct_ReturnsTrue()
        {
            var product = new Product()
            {
                Id = 3,
                Name = "Test3",
                Description = "Test3",
                Price = 3.3m,
            };

            var result = await _productService.TryAddProductAsync(product);

            Assert.IsTrue(result);
            Assert.AreEqual(3, _dbContext.Products.Count()); 
        }

        private void SeedTestData()
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Test",
                    Description = "Test",
                    Price = 1.2m,
                },
                new Product()
                {
                    Id = 2,
                    Name = "Test2",
                    Description = "Test2",
                    Price = 2.2m,
                }
            };

            _dbContext.Products.AddRange(products);
            _dbContext.SaveChanges();
        }
    }
}