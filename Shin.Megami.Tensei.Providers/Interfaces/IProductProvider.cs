using Shin.Megami.Tensei.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product related service methods.
    /// </summary>
    public interface IProductProvider
    {
        Task<Product> GetProductByIdAsync(int productId);

        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(int id, Product updatedProduct);

        Task DeleteProductByIdAsync(int productId);

    }
}
