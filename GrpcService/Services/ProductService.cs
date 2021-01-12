using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcServer.Interfaces;
using GrpcServer.Model;
using Microsoft.Extensions.Logging;

namespace GrpcService.Services
{
    public class ProductService : Product.ProductBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;

        public ProductService(ILogger<ProductService> logger, ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public override async Task<CategoryModel> CreateNewCategory(CategoryModel request, ServerCallContext context)
        {
            var result = await _categoryRepository.AddCategory(request);
            var newCategoryModel = new CategoryModel
            {
                Name = result.Name
            };

            return await Task.FromResult(newCategoryModel);
        }

        public override async Task<CategoryModel> GetCategoryInfo(CategoryLookupModel request, ServerCallContext context)
        {
            var result = await _categoryRepository.GetCategory(request.Id);

            var category = new CategoryModel
            {
                Name = result.Name
            };

            return await Task.FromResult(category);
        }


        public override async Task<CategoryModel> ModifyCategory(ModifyCategoryModel request, ServerCallContext context)
        {
            var result = await _categoryRepository.ModifyCategory(request);

            var category = new CategoryModel
            {
                Name = result.Name,
            };

            return await Task.FromResult(category);
        }

        public override async Task<CategoryModel> DeleteCategory(CategoryLookupModel request, ServerCallContext context)
        {
            var result = await _categoryRepository.DeleteCategory(request.Id);

            var category = new CategoryModel
            {
                Name = result.Name
            };

            return await Task.FromResult(category);
        }

        public override async Task<ProductModel> CreateNewProduct(ProductModel request, ServerCallContext context)
        {
            var result = await _productRepository.AddProduct(request);

            var product = new ProductModel()
            {
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                CategoryId = result.CategoryId,
            };

            return await Task.FromResult(product);
        }

        public override async Task<ProductModel> GetProductInfo(ProductLookupModel request, ServerCallContext context)
        {
            var result = await _productRepository.GetProduct(request.Id);

            var product = new ProductModel()
            {
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                CategoryId = result.CategoryId,
            };

            return await Task.FromResult(product);
        }

        public override async Task<ProductModel> DeleteProduct(ProductLookupModel request, ServerCallContext context)
        {
            var result = await _productRepository.DeleteProduct(request.Id);

            var product = new ProductModel()
            {
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                CategoryId = result.CategoryId,
            };

            return await Task.FromResult(product);
        }

        public override async Task<ProductModel> ModifyProduct(ProductModifyModel request, ServerCallContext context)
        {
            var result = await _productRepository.ModifyProduct(request);

            var product = new ProductModel()
            {
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                CategoryId = result.CategoryId,
            };

            return await Task.FromResult(product);
        }

        public override async Task<ProductModel> ChangeProductCategory(ChangeProductCategoryModel request, ServerCallContext context)
        {
            var result = await _productRepository.ChangeCategory(request);

            var product = new ProductModel()
            {
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                CategoryId = result.CategoryId,
            };

            return await Task.FromResult(product);
        }

        public override async Task<GetProductsByCategoryModel> GetProductsByCategory(CategoryLookupModel request, ServerCallContext context)
        {
            var result = await _productRepository.GetProductsByCategory(request.Id);

            var list = new GetProductsByCategoryModel();

            foreach (var products in result)
            {
                var temp = new ProductModel()
                {
                    Name = products.Name,
                    Description = products.Description,
                    Price = products.Price,
                    CategoryId = products.CategoryId,
                };

                list.Producs.Add(temp);
            }

            return list;
        }
    }
}