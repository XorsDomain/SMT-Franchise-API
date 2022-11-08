using Shin.Megami.Tensei.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for Product repository methods.
    /// </summary>
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int ProductId);

        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> CreateProductAsync(Product Product);

        Task<Product> UpdateProductAsync(Product updatedProduct);

        Task DeleteProductAsync(Product Product);
    }
}
