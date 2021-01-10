using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcServer.Model;
using Microsoft.EntityFrameworkCore;
using ProductModel = GrpcService.ProductModel;

namespace GrpcServer.DataAccess
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ProductModel>()
                .HasOne(p => p.Category)
                .WithMany( c => Products)
                .HasForeignKey(c => CategoryId);
        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }
}
