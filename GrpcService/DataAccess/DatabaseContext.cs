using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcServer.Model;
using GrpcService;
using Microsoft.EntityFrameworkCore;
using Product = GrpcServer.Model.Product;
using ProductModel = GrpcService.ProductModel;

namespace GrpcServer.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
