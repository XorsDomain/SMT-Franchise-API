using Shin.Megami.Tensei.Data.Interfaces;
using Shin.Megami.Tensei.Data.Model;
using Shin.Megami.Tensei.Providers.Interfaces;
using Shin.Megami.Tensei.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shin.Megami.Tensei.Data.Repositories;

namespace Shin.Megami.Tensei.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the P5R interface, providing service methods for persona.
    /// </summary>
    public class P5RProvider : IP5RProvider
    {
        private readonly ILogger<P5RProvider> _logger;
        private readonly IP5RProvider _p5RProvider;
        private readonly IP5RRepository _p5RRepository;

        public P5RProvider(IP5RRepository P5RRepository, ILogger<P5RProvider> logger)
        {
            _logger = logger;
            _p5RRepository = P5RRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the persona with the provided id from the database.
        /// </summary>
        /// <param name="personaId">The id of the persona to retrieve.</param>
        /// <returns>The persona.</returns>
        public async Task<Persona5Royal> GetPersonaByIdAsync(int personaId)
        {
            Persona5Royal persona;

            try
            {
                persona = await _p5RRepository.GetPersonaByIdAsync(personaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (personaId == null || personaId == default)
            {
                _logger.LogInformation($"DDStoryMegaTen with id: {personaId} could not be found.");
                throw new NotFoundException($"DDStoryMegaTen with id: {personaId} could not be found.");

            }

            return persona;
        }

        /// <summary>
        /// Asynchronously retrieves the persona or personas with the provided field parameters from the database.
        /// </summary>
        /// <returns>the persona or personas</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="NotFoundException"></exception>
        public async Task<IEnumerable<Persona5Royal>> GetAllPersonaAsync()
        {
            IEnumerable<Persona5Royal> personas;

            try
            {
                personas = await _p5RRepository.GetAllPersonasAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            
            return personas;
        }

        /// <summary>
        /// Asynchronously adds a persona to the database.
        /// </summary>
        /// <param name="newPersona"></param>
        /// <returns>persona</returns>
        /// <exception cref="ServiceUnavailableException"></exception>

        public async Task<Persona5Royal> CreatePersonaAsync(Persona5Royal newPersona)
        {
            Persona5Royal savedPersona;
            IEnumerable<Persona5Royal> personas;

            try
            {
                personas = await _p5RRepository.GetAllPersonasAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            try
            {
                savedPersona = await _p5RRepository.CreatePersonaAsync(newPersona);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return savedPersona;
        }

        /// <summary>
        /// Asychronously updates persona by given id
        /// </summary>
        /// <param name="id">Id of persona to update</param>
        /// <param name="updatedPersona">Persona being updated</param>
        /// <returns>Updated persona</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        /// <exception cref="NotFoundException"></exception>

        public async Task<Persona5Royal> UpdatePersonaAsync(int personaId, Persona5Royal updatedPersona)
        {
            Persona5Royal existingPersona;
            IEnumerable<Persona5Royal> personas;

            try
            {
                personas = await _p5RRepository.GetAllPersonasAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }


            try
            {
                existingPersona = await _p5RRepository.GetPersonaByIdAsync(personaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (existingPersona == default)
            {
                _logger.LogInformation($"DDStoryMegaTen with id: {personaId} does not exist.");
                throw new NotFoundException($"DDStoryMegaTen with id: {personaId} not found.");
            }

            if (updatedPersona.Id != existingPersona.Id)
            {
                _logger.LogInformation("Edited product id must be the same as original product id.");
                throw new BadRequestException("Edited product id must be the same as original product id.");
            }

            try
            {
                await _p5RRepository.UpdatePersonaAsync(updatedPersona);
                _logger.LogInformation("Persona updated.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database");
            }
            return existingPersona;
        }

        /// <summary>
        /// asynchronously deletes a persona in the database by a given id
        /// </summary>
        /// <param name="personaId">id of persona to be deleted</param>
        /// <exception cref="NotFoundException"></exception>

        public async Task DeletePersonaByIdAsync(int personaId)
        {
            var _persona = await _p5RRepository.GetPersonaByIdAsync(personaId);

            if (_persona != null)
            {
                await _p5RRepository.DeletePersonaAsync(_persona);
            }
            else
            {
                throw new NotFoundException($"Persona with ID {personaId} could not be found.");
            }

        }
    }
}
