using Shin.Megami.Tensei.Data.Context;
using Shin.Megami.Tensei.Data.Interfaces;
using Shin.Megami.Tensei.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the Encounter repository.
    /// </summary>
    public class EncounterRepository : IEncounterRepository
    {
        private readonly IHealthCtx _ctx;

        public EncounterRepository(IHealthCtx ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// This method gets a Encounter by its id.
        /// </summary>
        /// <param name="encounterId"></param>
        /// <returns>Encounter by given ID</returns>
        public async Task<Encounter> GetEncounterByIdAsync(int encounterId)
        {
            return await _ctx.Encounters.AsNoTracking().FirstOrDefaultAsync(i => i.Id == encounterId);
        }

        /// <summary>
        /// method to get all encounters in the backend and return a list of Encounters
        /// </summary>
        /// <returns>a list of Encounters</returns>
        public async Task<IEnumerable<Encounter>> GetAllEncountersAsync()

        {
            return await _ctx.Encounters.ToListAsync();
        }


        /// <summary>
        /// Adds a Encounter to the database.
        /// </summary>
        /// <param name="encounter"></param>
        /// <returns>Encounter</returns>

        public async Task<Encounter> CreateEncounterAsync(Encounter encounter)
        {
            _ctx.Encounters.Add(encounter);
            await _ctx.SaveChangesAsync();

            return encounter;
        }

        /// <summary>
        /// Updates a Encounter
        /// </summary>
        /// <param name="updatedEncounter">Encounter to be updated</param>
        /// <returns>Encounter</returns>

        public async Task<Encounter> UpdateEncounterAsync(Encounter updatedEncounter)
        {
            _ctx.Encounters.Update(updatedEncounter);
            await _ctx.SaveChangesAsync();

            return updatedEncounter;
        }

        /// <summary>
        /// This method deletes a Encounter
        /// </summary>
        /// <param name="encounter">Encounter to be deleted</param>
        public async Task DeleteEncounterAsync(Encounter encounter)
        {
            _ctx.Encounters.Remove(encounter);
            await _ctx.SaveChangesAsync();
        }

    }

}
