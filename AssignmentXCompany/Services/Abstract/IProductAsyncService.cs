using AssignmentXCompany.Models;

namespace AssignmentXCompany.Services.Abstract
{
    public interface IProductAsyncService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product?> TryGetProductByIdAsync(int productId);
        Task<bool> TryAddProductAsync(Product product);
        Task<bool> TryUpdateProduct(Product product);
        Task<bool> TryDeleteProduct(int productId);
    }
}
