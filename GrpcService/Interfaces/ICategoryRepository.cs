using System.Threading.Tasks;
using GrpcServer.Model;
using GrpcService;

namespace GrpcServer.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> AddCategory(CategoryModel category);
        public Task<Category> GetCategory(int id);

        public Task<Category> DeleteCategory(int id);

        public Task<Category> ModifyCategory(ModifyCategoryModel categoryModel);
    }
}