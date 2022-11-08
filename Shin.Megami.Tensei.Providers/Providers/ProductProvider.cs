using Shin.Megami.Tensei.Data.Interfaces;
using Shin.Megami.Tensei.Data.Model;
using Shin.Megami.Tensei.Providers.Interfaces;
using Shin.Megami.Tensei.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IProductProvider interface, providing service methods for products.
    /// </summary>
    public class ProductProvider : IProductProvider
    {
        private readonly ILogger<ProductProvider> _logger;
        private readonly IProductRepository _ProductRepository;

        public ProductProvider(IProductRepository ProductRepository, ILogger<ProductProvider> logger)
        {
            _logger = logger;
            _ProductRepository = ProductRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the product with the provided id from the database.
        /// </summary>
        /// <param name="ProductId">The id of the product to retrieve.</param>
        /// <returns>The product.</returns>
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            Product product;

            try
            {
                product = await _ProductRepository.GetProductByIdAsync(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (product == null || product == default)
            {
                _logger.LogInformation($"Product with id: {productId} could not be found.");
                throw new NotFoundException($"Product with id: {productId} could not be found.");

            }

            return product;
        }

        /// <summary>
        /// Asynchronously retrieves the product or products with the provided field parameters from the database.
        /// </summary>
        /// <returns>the product or products</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="NotFoundException"></exception>
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            IEnumerable<Product> products;

            try
            {
                products = await _ProductRepository.GetAllProductsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            
            return products;
        }

        /// <summary>
        /// Asynchronously adds a product to the database.
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns>product</returns>
        /// <exception cref="ServiceUnavailableException"></exception>

        public async Task<Product> CreateProductAsync(Product newProduct)
        {
            Product savedProduct;
            IEnumerable<Product> products;

            try
            {
                products = await _ProductRepository.GetAllProductsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            try
            {
                savedProduct = await _ProductRepository.CreateProductAsync(newProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return savedProduct;
        }

        /// <summary>
        /// Asychronously updates product by given id
        /// </summary>
        /// <param name="id">Id of product to update</param>
        /// <param name="updatedProduct">Product being updated</param>
        /// <returns>Updated product</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        /// <exception cref="NotFoundException"></exception>

        public async Task<Product> UpdateProductAsync(int productId, Product updatedProduct)
        {
            Product existingProduct;
            IEnumerable<Product> products;

            try
            {
                products = await _ProductRepository.GetAllProductsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }


            try
            {
                existingProduct = await _ProductRepository.GetProductByIdAsync(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (existingProduct == default)
            {
                _logger.LogInformation($"Product with id: {productId} does not exist.");
                throw new NotFoundException($"Product with id: {productId} not found.");
            }

            if (updatedProduct.Id != existingProduct.Id)
            {
                _logger.LogInformation("Edited product id must be the same as original product id.");
                throw new BadRequestException("Edited product id must be the same as original product id.");
            }

            try
            {
                await _ProductRepository.UpdateProductAsync(updatedProduct);
                _logger.LogInformation("Product updated.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database");
            }
            return existingProduct;
        }

        /// <summary>
        /// asynchronously deletes a product in the database by a given id
        /// </summary>
        /// <param name="productId">id of product to be deleted</param>
        /// <exception cref="NotFoundException"></exception>

        public async Task DeleteProductByIdAsync(int productId)
        {
            var _product = await _ProductRepository.GetProductByIdAsync(productId);

            if (_product != null)
            {
                await _ProductRepository.DeleteProductAsync(_product);
            }
            else
            {
                throw new NotFoundException($"Product with ID {productId} could not be found.");
            }

        }
    }
}
