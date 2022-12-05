using Shin.Megami.Tensei.Data.Context;
using Shin.Megami.Tensei.Data.Interfaces;
using Shin.Megami.Tensei.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the Persona5Royal repository.
    /// </summary>
    public class P5RRepository : IP5RRepository
    {
        private readonly ISMTCtx _ctx;

        public P5RRepository(ISMTCtx ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// This method gets a persona by its id.
        /// </summary>
        /// <param name="personaId"></param>
        /// <returns>Persona by given ID</returns>
        public async Task<Persona5Royal> GetPersonaByIdAsync(int personaId)
        {
            return await _ctx.P5RPersonas.AsNoTracking().FirstOrDefaultAsync(i => i.Id == personaId);
        }

        /// <summary>
        /// method to get all persona in the backend and return a list of persona
        /// </summary>
        /// <returns>a list of persona</returns>
        public async Task<IEnumerable<Persona5Royal>> GetAllPersonasAsync()

        {
            return await _ctx.P5RPersonas.ToListAsync();
        }


        /// <summary>
        /// Adds a persona to the database.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>persona</returns>

        public async Task<Persona5Royal> CreatePersonaAsync(Persona5Royal persona)
        {
            _ctx.P5RPersonas.Add(persona);
            await _ctx.SaveChangesAsync();

            return persona;
        }

        /// <summary>
        /// Updates a persona
        /// </summary>
        /// <param name="updatedPersona">Persona to be updated</param>
        /// <returns>Persona</returns>

        public async Task<Persona5Royal> UpdatePersonaAsync(Persona5Royal updatedPersona)
        {
            _ctx.P5RPersonas.Update(updatedPersona);
            await _ctx.SaveChangesAsync();

            return updatedPersona;
        }

        /// <summary>
        /// This method deletes a Persona
        /// </summary>
        /// <param name="persona">Persona to be deleted</param>
        public async Task DeletePersonaAsync(Persona5Royal persona)
        {
            _ctx.P5RPersonas.Remove(persona);
            await _ctx.SaveChangesAsync();
        }

    }

}
