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
    /// This class provides the implementation of the IEncounterProvider interface, providing service methods for encounters.
    /// </summary>
    public class EncounterProvider : IEncounterProvider
    {
        private readonly ILogger<EncounterProvider> _logger;
        private readonly IEncounterRepository _encounterRepository;

        public EncounterProvider(IEncounterRepository encounterRepository, ILogger<EncounterProvider> logger)
        {
            _logger = logger;
            _encounterRepository = encounterRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the encounter with the provided id from the database.
        /// </summary>
        /// <param name="EncounterId">The id of the encounter to retrieve.</param>
        /// <returns>The encounter.</returns>
        public async Task<Encounter> GetEncounterByIdAsync(int encounterId)
        {
            Encounter encounter;

            try
            {
                encounter = await _encounterRepository.GetEncounterByIdAsync(encounterId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (encounter == null || encounter == default)
            {
                _logger.LogInformation($"Encounter with id: {encounterId} could not be found.");
                throw new NotFoundException($"Encounter with id: {encounterId} could not be found.");

            }

            return encounter;
        }

        /// <summary>
        /// Asynchronously retrieves the encounter or encounters with the provided field parameters from the database.
        /// </summary>
        /// <returns>the encounter or encounters</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="NotFoundException"></exception>
        public async Task<IEnumerable<Encounter>> GetAllEncountersAsync()
        {
            IEnumerable<Encounter> encounters;

            try
            {
                encounters = await _encounterRepository.GetAllEncountersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            
            return encounters;
        }

        /// <summary>
        /// Asynchronously adds a encounter to the database.
        /// </summary>
        /// <param name="newEncounter"></param>
        /// <returns>encounter</returns>
        /// <exception cref="ServiceUnavailableException"></exception>

        public async Task<Encounter> CreateEncounterAsync(Encounter newEncounter)
        {
            Encounter savedEncounter;
            IEnumerable<Encounter> encounters;

            try
            {
                encounters = await _encounterRepository.GetAllEncountersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            try
            {
                savedEncounter = await _encounterRepository.CreateEncounterAsync(newEncounter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return savedEncounter;
        }

        /// <summary>
        /// Asychronously updates encounter by given id
        /// </summary>
        /// <param name="id">Id of encounter to update</param>
        /// <param name="updatedEncounter">Encounter being updated</param>
        /// <returns>Updated encounter</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        /// <exception cref="NotFoundException"></exception>

        public async Task<Encounter> UpdateEncounterAsync(int encounterId, Encounter updatedEncounter)
        {
            Encounter existingEncounter;
            IEnumerable<Encounter> encounters;

            try
            {
                encounters = await _encounterRepository.GetAllEncountersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }


            try
            {
                existingEncounter = await _encounterRepository.GetEncounterByIdAsync(encounterId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }


            if (existingEncounter == default)
            {
                _logger.LogInformation($"Encounter with id: {encounterId} does not exist.");
                throw new NotFoundException($"Encounter with id: {encounterId} not found.");
            }

            if (updatedEncounter.Id != existingEncounter.Id)
            {
                _logger.LogInformation("Edited encounter id must be the same as original encounter id.");
                throw new BadRequestException("Edited encounter id must be the same as original encounter id.");
            }

            try
            {
                await _encounterRepository.UpdateEncounterAsync(updatedEncounter);
                _logger.LogInformation("Encounter updated.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database");
            }
            return existingEncounter;
        }

        /// <summary>
        /// asynchronously deletes a encounter in the database by a given id
        /// </summary>
        /// <param name="encounterId">id of encounter to be deleted</param>
        /// <exception cref="NotFoundException"></exception>

        public async Task DeleteEncounterByIdAsync(int encounterId)
        {
            var _encounter = await _encounterRepository.GetEncounterByIdAsync(encounterId);

            if (_encounter != null)
            {
                await _encounterRepository.DeleteEncounterAsync(_encounter);
            }
            else
            {
                throw new NotFoundException($"Encounter with ID {encounterId} could not be found.");
            }
        }
    }
}
