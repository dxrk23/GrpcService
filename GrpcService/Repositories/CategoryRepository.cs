using System.Threading.Tasks;
using GrpcServer.DataAccess;
using GrpcServer.Interfaces;
using GrpcServer.Model;
using GrpcService;
using Microsoft.EntityFrameworkCore;

namespace GrpcServer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;

        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategory(CategoryModel category)
        {
            var newCategory = new Category
            {
                Name = category.Name
            };

            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return newCategory;
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var categoryToDelete = await _context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(id));
            _context.Categories.Remove(categoryToDelete);
            await _context.SaveChangesAsync();
            return categoryToDelete;
        }

        public async Task<Category> ModifyCategory(ModifyCategoryModel categoryModel)
        {
            var categoryToModify = await _context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(categoryModel.Id));
            categoryToModify.Name = categoryModel.NewName;
            await _context.SaveChangesAsync();
            return categoryToModify;
        }
    }
}