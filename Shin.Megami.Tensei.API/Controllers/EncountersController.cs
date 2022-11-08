﻿using AutoMapper;
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Shin.Megami.Tensei.DTOs.Encounters;
using Shin.Megami.Tensei.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shin.Megami.Tensei.Data.Model;

namespace Shin.Megami.Tensei.API.Controllers
{
    /// <summary>
    /// The EncountersController exposes endpoints for Encounter related actions.
    /// </summary>
    [ApiController]
    [Route("/products/{Product.Id}/encounters")]
    public class EncountersController : ControllerBase
    {
        private readonly ILogger<EncountersController> _logger;
        private readonly IEncounterProvider _encounterProvider;
        private readonly IMapper _mapper;

        public EncountersController(
            ILogger<EncountersController> logger,
            IEncounterProvider encounterProvider,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _encounterProvider = encounterProvider;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EncounterDTO>> GetEncounterByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetEncounterByIdAsync for id: {id}");

            var encounter = await _encounterProvider.GetEncounterByIdAsync(id);
            var EncounterDTO = _mapper.Map<EncounterDTO>(encounter);

            return Ok(EncounterDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EncounterDTO>>> GetAllEncountersAsync()
        {
            var result = await _encounterProvider.GetAllEncountersAsync();

            IEnumerable<EncounterDTO> encounterDTO = _mapper.Map<IEnumerable<EncounterDTO>>(result);
            return Ok(encounterDTO);
        }

        [HttpPost]
        public async Task<ActionResult<EncounterDTO>> CreateEncounterAsync([FromBody]EncounterDTO encounterToCreate)
        {
            _logger.LogInformation("Request recieved for CreateEncounterAsync");

            var encounter = _mapper.Map<Encounter>(encounterToCreate);
            var newEncounter = await _encounterProvider.CreateEncounterAsync(encounter);
            var encounterDTO = _mapper.Map<EncounterDTO>(newEncounter);
            return Created("/products/{Product.Id}/encounters", encounterDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EncounterDTO>> UpdateEncounterAsync(int id, [FromBody] EncounterDTO encounterToUpdate)
        {
            _logger.LogInformation("Request received for UpdateEncounterAsync");

            var encounter = _mapper.Map<Encounter>(encounterToUpdate);
            var updatedEncounter = await _encounterProvider.UpdateEncounterAsync(id, encounter);
            var encounterDTO = _mapper.Map<EncounterDTO>(updatedEncounter);

            return Ok(encounterDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEncounterById(int id)
        {
            await _encounterProvider.DeleteEncounterByIdAsync(id);
            return NoContent();
        }

    }
}
