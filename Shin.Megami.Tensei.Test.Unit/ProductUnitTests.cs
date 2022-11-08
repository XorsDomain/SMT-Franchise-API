using System;
using Xunit;
using Moq;
using Shin.Megami.Tensei.Providers.Providers;
using Shin.Megami.Tensei.Data.Interfaces;
using Microsoft.Extensions.Logging;
using Shin.Megami.Tensei.Data.Model;
using System.Linq;
using System.Collections.Generic;
using Shin.Megami.Tensei.Providers.Interfaces;
using Shin.Megami.Tensei.Utilities.HttpResponseExceptions;

namespace Shin.Megami.Tensei.Test.Unit
{
    public class ProductUnitTests
    {
        private readonly List<Product> products;
        private readonly IProductProvider productProvider;
        private readonly Mock<IProductRepository> productRepo;
        private readonly Mock<ILogger<ProductProvider>> logger;

        public ProductUnitTests()
        {
            productRepo = new Mock<IProductRepository>();
            logger = new Mock<ILogger<ProductProvider>>();
            productProvider = new ProductProvider(productRepo.Object, logger.Object);

            products = new List<Product>()
            {
                new Product() {Id = 1, Gender = "Male"}
            };

        }

        [Fact]
        public async void GetProductsByIdAsync_IdExistsReturnsProduct()
        {
            var product = products.Single(x => x.Id == 1);
            productRepo.Setup(m => m.GetProductByIdAsync(1)).ReturnsAsync(product);

            var actual = await productRepo.Object.GetProductByIdAsync(1);
            Assert.Same(product, actual);
            Assert.Equal(1, actual.Id);
        }

        [Fact]
        public async void GetProductByIdAsync_DatabaseErrorReturnsException()
        {
            var exception = new ServiceUnavailableException("There was a problem connecting to the database.");

            productRepo.Setup(m => m.GetProductByIdAsync(1)).ThrowsAsync(exception);
            try
            {
                await productProvider.GetProductByIdAsync(1);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }

        [Fact]
        public async void GetProductByIdAsync_IdIsNullReturnsNotFoundError()
        {
            Product product = null;
            var productId = 2;
            var exception = new NotFoundException($"Product with id: {productId} could not be found.");

            productRepo.Setup(m => m.GetProductByIdAsync(productId)).ReturnsAsync(product);
            try
            {
                await productProvider.GetProductByIdAsync(productId);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }

        [Fact]
        public async void GetProductByIdAsync_IdIsDefaultReturnsNotFoundError()
        {
            Product product = default;
            var productId = 2;
            var exception = new NotFoundException($"Product with id: {productId} could not be found.");

            productRepo.Setup(m => m.GetProductByIdAsync(productId)).ReturnsAsync(product);
            try
            {
                await productProvider.GetProductByIdAsync(productId);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }

    }
}

