using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcService;
using Product = GrpcServer.Model.Product;

namespace GrpcServer.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> AddProduct(ProductModel product);
        public Task<Product> GetProduct(int id);

        public Task<Product> DeleteProduct(int id);

        public Task<Product> ModifyProduct(int id, ProductModel product);

        public Task<Product> ChangeCategory(int productId, int categoryId);

        public Task<List<Product>> GetProductsByCategory(int id);
    }
}