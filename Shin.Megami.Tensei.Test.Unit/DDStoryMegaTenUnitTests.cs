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
    public class DDStoryMegaTenUnitTests
    {
        private readonly List<DDStoryMegaTen> dDSMTDemons;
        private readonly IDDStoryMegaTenProvider dDStoryMegaTenProvider;
        private readonly Mock<IDDStoryMegaTenRepository> dDStoryMegaTenRepo;
        private readonly Mock<ILogger<DDStoryMegaTenProvider>> logger;

        public DDStoryMegaTenUnitTests()
        {
            dDStoryMegaTenRepo = new Mock<IDDStoryMegaTenRepository>();
            logger = new Mock<ILogger<DDStoryMegaTenProvider>>();
            dDStoryMegaTenProvider = new DDStoryMegaTenProvider(dDStoryMegaTenRepo.Object, logger.Object);

            dDSMTDemons = new List<DDStoryMegaTen>()
            {
                new DDStoryMegaTen() {Id = 1, Origin = "Hindu"}
            };

        }

        [Fact]
        public async void GetDemonsByIdAsync_IdExistsReturnsDemon()
        {
            var demon = dDSMTDemons.Single(x => x.Id == 1);
            dDStoryMegaTenRepo.Setup(m => m.GetDemonByIdAsync(1)).ReturnsAsync(demon);

            var actual = await dDStoryMegaTenRepo.Object.GetDemonByIdAsync(1);
            Assert.Same(demon, actual);
            Assert.Equal(1, actual.Id);
        }

        [Fact]
        public async void GetDemonByIdAsync_DatabaseErrorReturnsException()
        {
            var exception = new ServiceUnavailableException("There was a problem connecting to the database.");

            dDStoryMegaTenRepo.Setup(m => m.GetDemonByIdAsync(1)).ThrowsAsync(exception);
            try
            {
                await dDStoryMegaTenProvider.GetDemonByIdAsync(1);
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
            DDStoryMegaTen demon = null;
            var demonId = 2;
            var exception = new NotFoundException($"Demon with id: {demonId} could not be found.");

            dDStoryMegaTenRepo.Setup(m => m.GetDemonByIdAsync(demonId)).ReturnsAsync(demon);
            try
            {
                await dDStoryMegaTenProvider.GetDemonByIdAsync(demonId);
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
            DDStoryMegaTen demon = default;
            var demonId = 2;
            var exception = new NotFoundException($"Demon with id: {demonId} could not be found.");

            dDStoryMegaTenRepo.Setup(m => m.GetDemonByIdAsync(demonId)).ReturnsAsync(demon);
            try
            {
                await dDStoryMegaTenProvider.GetDemonByIdAsync(demonId);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }

    }
}

