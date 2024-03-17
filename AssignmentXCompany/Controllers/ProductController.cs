using AssignmentXCompany.Models;
using AssignmentXCompany.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentXCompany.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //Task 2.1
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _productService.GetProducts();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            var result = _productService.TryGetProductById(id);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var isSuccess = _productService.TryAddProduct(product);
            if (!isSuccess)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var isSuccess = _productService.TryUpdateProduct(product);
            if (!isSuccess)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int productId)
        {
            var isSuccess = _productService.TryDeleteProduct(productId);
            if (!isSuccess)
                return BadRequest();

            return Ok();
        }
    }
}