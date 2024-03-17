using AssignmentXCompany.Models;
using AssignmentXCompany.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AssignmentXCompany.Controllers
{
    //[Authorize] //Task 3.2
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductSqlController : ControllerBase
    {
        //Task 3.1
        private readonly IProductAsyncService _productAsyncService;
        private readonly IMemoryCache _memoryCache;//Task 3.4
        private readonly string productsMemoryKey = "products";

        public ProductSqlController(IProductAsyncService productAsyncService, IMemoryCache memoryCache)
        {
            _productAsyncService = productAsyncService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            if (!_memoryCache.TryGetValue(productsMemoryKey, out var products))
            {
                products = await _productAsyncService.GetProductsAsync();
                _memoryCache.Set(productsMemoryKey, products);
            }

            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var cacheKey = $"product-{id}";
            if (!_memoryCache.TryGetValue(cacheKey, out var product))
            {
                product = await _productAsyncService.TryGetProductByIdAsync(id);
                if (product == null)
                    return BadRequest();
                _memoryCache.Set(cacheKey, product);
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var isSuccess = await _productAsyncService.TryAddProductAsync(product);
            if (!isSuccess)
                return BadRequest();

            _memoryCache.Remove(productsMemoryKey);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var isSuccess = await _productAsyncService.TryUpdateProductAsync(product);
            if (!isSuccess)
                return BadRequest();

            _memoryCache.Remove(productsMemoryKey);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var isSuccess = await _productAsyncService.TryDeleteProductAsync(productId);
            if (!isSuccess)
                return BadRequest();

            _memoryCache.Remove(productsMemoryKey);
            return Ok();
        }
    }
}
