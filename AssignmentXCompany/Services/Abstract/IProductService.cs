using AssignmentXCompany.Models;

namespace AssignmentXCompany.Services.Abstract
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? TryGetProductById(int productId);
        bool TryAddProduct(Product product);
        bool TryUpdateProduct(Product product);
        bool TryDeleteProduct(int productId);
    }
}
