using Shin.Megami.Tensei.Data.Context;
using Shin.Megami.Tensei.Data.Interfaces;
using Shin.Megami.Tensei.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the Product repository.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ISMTCtx _ctx;

        public ProductRepository(ISMTCtx ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// This method gets a Product by its id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Product by given ID</returns>
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _ctx.Products.AsNoTracking().FirstOrDefaultAsync(i => i.Id == productId);
        }

        /// <summary>
        /// method to get all Products in the backend and return a list of Products
        /// </summary>
        /// <returns>a list of Products</returns>
        public async Task<IEnumerable<Product>> GetAllProductsAsync()

        {
            return await _ctx.Products.ToListAsync();
        }


        /// <summary>
        /// Adds a Product to the database.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Product</returns>

        public async Task<Product> CreateProductAsync(Product product)
        {
            _ctx.Products.Add(product);
            await _ctx.SaveChangesAsync();

            return product;
        }

        /// <summary>
        /// Updates a Product
        /// </summary>
        /// <param name="product">Product to be updated</param>
        /// <returns>Product</returns>

        public async Task<Product> UpdateProductAsync(Product updatedProduct)
        {
            _ctx.Products.Update(updatedProduct);
            await _ctx.SaveChangesAsync();

            return updatedProduct;
        }

        /// <summary>
        /// This method deletes a Product
        /// </summary>
        /// <param name="product">Product to be deleted</param>
        public async Task DeleteProductAsync(Product product)
        {
            _ctx.Products.Remove(product);
            await _ctx.SaveChangesAsync();
        }

    }

}
