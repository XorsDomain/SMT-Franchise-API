using Shin.Megami.Tensei.DTOs.Persona5Royals;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Shin.Megami.Tensei.Test.Integration
{
    public class Persona5RoyalIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task GetPersonas_Returns200()
        {
            var response = await _client.GetAsync("/p5rpersonas");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetPersonaById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/p5rpersonas/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<Persona5RoyalDTO>();
            Assert.Equal(1, content.Id);
        }


        [Fact]
        public async Task GetPersonaById_GivenInvalidId_Returns400()
        {
            var response = await _client.GetAsync("/p5rpersonas/asdf");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetPersonaById_GivenNonexistingId_Returns404()
        {
            var response = await _client.GetAsync("/p5rpersonas/34567");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetPersonas_ReturnsCorrectAmount()
        {
            int count = 502;
            var response = await _client.GetAsync("/p5rpersonas");
            var content = await response.Content.ReadAsAsync<ICollection<Persona5RoyalDTO>>();
            Assert.Equal(count, content.Count);
        }
    }
}