using Shin.Megami.Tensei.DTOs.Products;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Shin.Megami.Tensei.Test.Integration
{
    public class ProductIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task GetProducts_Returns200()
        {
            var response = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProductById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/products/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<ProductDTO>();
            Assert.Equal(1, content.Id);
        }


        [Fact]
        public async Task GetProductById_GivenInvalidId_Returns400()
        {
            var response = await _client.GetAsync("/products/asdf");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetProductById_GivenNonexistingId_Returns404()
        {
            var response = await _client.GetAsync("/products/34567");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetProducts_ReturnsCorrectAmount()
        {
            int count = 502;
            var response = await _client.GetAsync("/products");
            var content = await response.Content.ReadAsAsync<ICollection<ProductDTO>>();
            Assert.Equal(count, content.Count);
        }
    }
}