using AssignmentXCompany.Data;
using AssignmentXCompany.Models;
using AssignmentXCompany.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AssignmentXCompany.Services.Concrete
{
    public class ProductFromSQLService : IProductAsyncService
    {
        private readonly AppDbContext _appDbContext;

        public ProductFromSQLService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _appDbContext.Products.ToListAsync();
            return products;
        }

        public async Task<bool> TryAddProductAsync(Product product)
        {
            try
            {
                var result = await _appDbContext.Products.AddAsync(product);
                if (result != null)
                {
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);//or log
                return false;
            }
        }

        public async Task<bool> TryDeleteProductAsync(int productId)
        {
            try
            {
                var deletedProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == productId);
                if (deletedProduct != null)
                {
                    _appDbContext.Products.Remove(deletedProduct);
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<Product?> TryGetProductByIdAsync(int productId)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return product;
        }

        public async Task<bool> TryUpdateProductAsync(Product product)
        {
            try
            {
                var existingProduct = await _appDbContext.Products.FindAsync(product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                    existingProduct.Description = product.Description;

                    _appDbContext.Products.Update(existingProduct);
                    await _appDbContext.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
