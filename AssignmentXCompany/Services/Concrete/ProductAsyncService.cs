using AssignmentXCompany.Models;
using AssignmentXCompany.Services.Abstract;

namespace AssignmentXCompany.Services.Concrete
{
    public class ProductAsyncService : IProductAsyncService
    {
        //Task 2.2
        private readonly List<Product> _products;
        public ProductAsyncService()
        {
            _products = ProductService.GetInitialData();
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            //This awaiting code may be sql op. this is just simulated

            var result = await Task.Run(() => { return _products; });
            return result;
        }

        public async Task<bool> TryAddProductAsync(Product product)
        {
            //This awaiting code may be sql op. this is just simulated

            if (product == null)
                return false;

            await Task.Run(() => _products.Add(product));
            return true;
        }

        public async Task<bool> TryDeleteProductAsync(int productId)
        {
            //This awaiting code may be sql op. this is just simulated

            var deletedProduct = _products.Find(product => product.Id == productId);
            if (deletedProduct == null)
                return false;

            var isSuccess = await Task.Run(() => _products.Remove(deletedProduct));
            return isSuccess;
        }

        public async Task<Product?> TryGetProductByIdAsync(int productId)
        {
            //This awaiting code may be sql op. this is just simulated

            var result = await Task.Run(() => _products.Find(product => product.Id == productId));
            return result;
        }

        public async Task<bool> TryUpdateProductAsync(Product productNew)
        {
            //This awaiting code may be sql op. this is just simulated

            var updatedIndex = _products.FindIndex(product => product.Id == productNew.Id);
            if (updatedIndex < 0)
                return false;

            await Task.Run(() => _products[updatedIndex] = productNew);
            return true;
        }
    }
}
