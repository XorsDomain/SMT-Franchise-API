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
    public class Persona5RoyalUnitTests
    {
        private readonly List<Persona5Royal> p5RPersonas;
        private readonly IP5RProvider p5RProvider;
        private readonly Mock<IP5RRepository> p5RRepo;
        private readonly Mock<ILogger<P5RProvider>> logger;

        public Persona5RoyalUnitTests()
        {
            p5RRepo = new Mock<IP5RRepository>();
            logger = new Mock<ILogger<P5RProvider>>();
            p5RProvider = new P5RProvider(p5RRepo.Object, logger.Object);

            p5RPersonas = new List<Persona5Royal>()
            {
                new Persona5Royal() {Id = 1, Origin = "Hindu"}
            };

        }

        [Fact]
        public async void GetPersonasByIdAsync_IdExistsReturnsPersona()
        {
            var persona = p5RPersonas.Single(x => x.Id == 1);
            p5RRepo.Setup(m => m.GetPersonaByIdAsync(1)).ReturnsAsync(persona);

            var actual = await p5RRepo.Object.GetPersonaByIdAsync(1);
            Assert.Same(persona, actual);
            Assert.Equal(1, actual.Id);
        }

        [Fact]
        public async void GetPersonaByIdAsync_DatabaseErrorReturnsException()
        {
            var exception = new ServiceUnavailableException("There was a problem connecting to the database.");

            p5RRepo.Setup(m => m.GetPersonaByIdAsync(1)).ThrowsAsync(exception);
            try
            {
                await p5RProvider.GetPersonaByIdAsync(1);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }

        [Fact]
        public async void GetDemonByIdAsync_IdIsNullReturnsNotFoundError()
        {
            Persona5Royal persona = null;
            var personaId = 2;
            var exception = new NotFoundException($"Persona with id: {personaId} could not be found.");

            p5RRepo.Setup(m => m.GetPersonaByIdAsync(personaId)).ReturnsAsync(persona);
            try
            {
                await p5RProvider.GetPersonaByIdAsync(personaId);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }

        [Fact]
        public async void GetDemonByIdAsync_IdIsDefaultReturnsNotFoundError()
        {
            Persona5Royal persona = default;
            var personaId = 2;
            var exception = new NotFoundException($"Demon with id: {personaId} could not be found.");

            p5RRepo.Setup(m => m.GetPersonaByIdAsync(personaId)).ReturnsAsync(persona);
            try
            {
                await p5RProvider.GetPersonaByIdAsync(personaId);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }

    }
}

