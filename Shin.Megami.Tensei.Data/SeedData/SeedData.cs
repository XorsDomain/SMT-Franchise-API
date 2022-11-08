using Shin.Megami.Tensei.Data.Model;
using Shin.Megami.Tensei.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using System;

namespace Shin.Megami.Tensei.Data.Context
{
    public static class Extensions
    {
        /// <summary>
        /// Produces a set of seed data to insert into the database on startup.
        /// </summary>
        /// <param name="modelBuilder">Used to build model base DbContext.</param>
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var productFactory = new ProductFactory();
            var ProductList = productFactory.GenerateRandomProducts(100);
            modelBuilder.Entity<Product>().HasData(ProductList);

        }
    }
}
