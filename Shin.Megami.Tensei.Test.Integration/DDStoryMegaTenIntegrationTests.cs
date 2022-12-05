using Shin.Megami.Tensei.DTOs.DDStoryMegaTens;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Shin.Megami.Tensei.Test.Integration
{
    public class DDStoryMegaTenIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task GetDemonss_Returns200()
        {
            var response = await _client.GetAsync("/megatendemons");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetDemonById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/megatendemons/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<DDStoryMegaTenDTO>();
            Assert.Equal(1, content.Id);
        }


        [Fact]
        public async Task GetDemonById_GivenInvalidId_Returns400()
        {
            var response = await _client.GetAsync("/megatendemons/asdf");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetDemonById_GivenNonexistingId_Returns404()
        {
            var response = await _client.GetAsync("/megatendemons/34567");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetDemons_ReturnsCorrectAmount()
        {
            int count = 502;
            var response = await _client.GetAsync("/megatendemons");
            var content = await response.Content.ReadAsAsync<ICollection<DDStoryMegaTenDTO>>();
            Assert.Equal(count, content.Count);
        }
    }
}