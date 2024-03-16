using AssignmentXCompany.Models;
using AssignmentXCompany.Services.Abstract;

namespace AssignmentXCompany.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;
        public ProductService()
        {
            _products = GetInitialData();
        }

        public Product? TryGetProductById(int productId)
        {
            var result = _products.Find(product => product.Id == productId);
            return result;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public bool TryAddProduct(Product product)
        {
            if (product == null)
                return false;

            _products.Add(product);
            return true;
        }

        public bool TryDeleteProduct(int productId)
        {
            var deletedProduct = _products.Find(product => product.Id == productId);
            if (deletedProduct == null)
                return false;

            var isSuccess = _products.Remove(deletedProduct);
            return isSuccess;
        }

        public bool TryUpdateProduct(Product productNew)
        {
            var updatedIndex = _products.FindIndex(product => product.Id == productNew.Id);
            if (updatedIndex < 0)
                return false;

            _products[updatedIndex] = productNew;
            return true;
        }

        #region Helpers
        public static List<Product> GetInitialData()
        {

            return [
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
                },
            ];
        }
        #endregion
    }
}
