using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcServer.DataAccess;
using GrpcServer.Interfaces;
using GrpcService;
using Product = GrpcServer.Model.Product;

namespace GrpcServer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Product> AddProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> ModifyProduct(int id, ProductModel product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> ChangeCategory(int productId, int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsByCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}