using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcServer.Interfaces;
using Microsoft.Extensions.Logging;

namespace GrpcService.Services
{
    public class ProductService : Product.ProductBase
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(ILogger<ProductService> logger, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public override Task<ProductModel> GetProductInfo(ProductLookupModel request, ServerCallContext context)
        {
            ProductModel output = new ProductModel();

            return Task.FromResult(output);
        }

        public override async Task<CategoryModel> CreateNewCategory(CategoryModel request, ServerCallContext context)
        {
            var result = await _categoryRepository.AddCategory(request);
            var newCategoryModel = new CategoryModel()
            {
                Name = result.Name,
            };

            return await Task.FromResult(newCategoryModel);
        }

        public override async Task<CategoryModel> GetCategoryInfo(CategoryLookupModel request, ServerCallContext context)
        {
            var result = await _categoryRepository.GetCategory(request.Id);

            var category = new CategoryModel()
            {
                Name = result.Name,
            };

            return await Task.FromResult(category);
        }
    }
}
