using AssignmentXCompany.Models;
using AssignmentXCompany.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentXCompany.Controllers
{
    [Authorize] //Task 3.2
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductSqlController : ControllerBase
    {
        //Task 3.1
        private readonly IProductAsyncService _productAsyncService;

        public ProductSqlController(IProductAsyncService productAsyncService)
        {
            _productAsyncService = productAsyncService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _productAsyncService.GetProductsAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productAsyncService.TryGetProductByIdAsync(id);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var isSuccess = await _productAsyncService.TryAddProductAsync(product);
            if (!isSuccess)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var isSuccess = await _productAsyncService.TryUpdateProductAsync(product);
            if (!isSuccess)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var isSuccess = await _productAsyncService.TryDeleteProductAsync(productId);
            if (!isSuccess)
                return BadRequest();

            return Ok();
        }
    }
}
