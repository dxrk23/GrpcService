using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcServer.Model;
using GrpcService;
using Microsoft.AspNetCore.Mvc;

namespace GrpcServer.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> AddCategory(CategoryModel category);
        public Task<Category> GetCategory(int id);

        public Task<Category> DeleteCategory(int id);

        public Task<Category> ModifyCategory(int id, CategoryModel category);
    }
}
