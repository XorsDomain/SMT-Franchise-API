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
    /// This class provides the implementation of the IDDStoryMegaTenProvider interface, providing service methods for demons.
    /// </summary>
    public class DDStoryMegaTenProvider : IDDStoryMegaTenProvider
    {
        private readonly ILogger<DDStoryMegaTenProvider> _logger;
        private readonly IDDStoryMegaTenRepository _DDStoryMegaTenRepository;

        public DDStoryMegaTenProvider(IDDStoryMegaTenRepository DDStoryMegaTenRepository, ILogger<DDStoryMegaTenProvider> logger)
        {
            _logger = logger;
            _DDStoryMegaTenRepository = DDStoryMegaTenRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the demon with the provided id from the database.
        /// </summary>
        /// <param name="demonId">The id of the demon to retrieve.</param>
        /// <returns>The demon.</returns>
        public async Task<DDStoryMegaTen> GetDemonByIdAsync(int demonId)
        {
            DDStoryMegaTen demon;

            try
            {
                demon = await _DDStoryMegaTenRepository.GetDemonByIdAsync(demonId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (demonId == null || demonId == default)
            {
                _logger.LogInformation($"DDStoryMegaTen with id: {demonId} could not be found.");
                throw new NotFoundException($"DDStoryMegaTen with id: {demonId} could not be found.");

            }

            return demon;
        }

        /// <summary>
        /// Asynchronously retrieves the demon or demons with the provided field parameters from the database.
        /// </summary>
        /// <returns>the demon or demon</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="NotFoundException"></exception>
        public async Task<IEnumerable<DDStoryMegaTen>> GetAllDemonsAsync()
        {
            IEnumerable<DDStoryMegaTen> demons;

            try
            {
                demons = await _DDStoryMegaTenRepository.GetAllDemonsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            
            return demons;
        }

        /// <summary>
        /// Asynchronously adds a demon to the database.
        /// </summary>
        /// <param name="newDemon"></param>
        /// <returns>demon</returns>
        /// <exception cref="ServiceUnavailableException"></exception>

        public async Task<DDStoryMegaTen> CreateDemonAsync(DDStoryMegaTen newDemon)
        {
            DDStoryMegaTen savedDemon;
            IEnumerable<DDStoryMegaTen> demons;

            try
            {
                demons = await _DDStoryMegaTenRepository.GetAllDemonsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            try
            {
                savedDemon = await _DDStoryMegaTenRepository.CreateDemonAsync(newDemon);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return savedDemon;
        }

        /// <summary>
        /// Asychronously updates demon by given id
        /// </summary>
        /// <param name="id">Id of demon to update</param>
        /// <param name="updatedDemon">Demon being updated</param>
        /// <returns>Updated demon</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        /// <exception cref="NotFoundException"></exception>

        public async Task<DDStoryMegaTen> UpdateDemonAsync(int demonId, DDStoryMegaTen updatedDemon)
        {
            DDStoryMegaTen existingDemon;
            IEnumerable<DDStoryMegaTen> demons;

            try
            {
                demons = await _DDStoryMegaTenRepository.GetAllDemonsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }


            try
            {
                existingDemon = await _DDStoryMegaTenRepository.GetDemonByIdAsync(demonId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (existingDemon == default)
            {
                _logger.LogInformation($"DDStoryMegaTen with id: {demonId} does not exist.");
                throw new NotFoundException($"DDStoryMegaTen with id: {demonId} not found.");
            }

            if (updatedDemon.Id != existingDemon.Id)
            {
                _logger.LogInformation("Edited demon id must be the same as original demon id.");
                throw new BadRequestException("Edited demon id must be the same as original demon id.");
            }

            try
            {
                await _DDStoryMegaTenRepository.UpdateDDStoryMegaTenAsync(updatedDemon);
                _logger.LogInformation("Demon updated.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database");
            }
            return existingDemon;
        }

        /// <summary>
        /// asynchronously deletes a demon in the database by a given id
        /// </summary>
        /// <param name="demonId">id of demon to be deleted</param>
        /// <exception cref="NotFoundException"></exception>

        public async Task DeleteDemonByIdAsync(int demonId)
        {
            var _demon = await _DDStoryMegaTenRepository.GetDemonByIdAsync(demonId);

            if (_demon != null)
            {
                await _DDStoryMegaTenRepository.DeleteDemonAsync(_demon);
            }
            else
            {
                throw new NotFoundException($"Demon with ID {demonId} could not be found.");
            }

        }
    }
}
