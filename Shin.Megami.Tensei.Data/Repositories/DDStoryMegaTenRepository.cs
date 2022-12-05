using Shin.Megami.Tensei.Data.Context;
using Shin.Megami.Tensei.Data.Interfaces;
using Shin.Megami.Tensei.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the DDStoryMegaTen repository.
    /// </summary>
    public class DDStoryMegaTenRepository : IDDStoryMegaTenRepository
    {
        private readonly ISMTCtx _ctx;

        public DDStoryMegaTenRepository(ISMTCtx ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// This method gets a Demon by its id.
        /// </summary>
        /// <param name="demonId"></param>
        /// <returns>Demon by given ID</returns>
        public async Task<DDStoryMegaTen> GetDemonByIdAsync(int demonId)
        {
            return await _ctx.DDSMTDemons.AsNoTracking().FirstOrDefaultAsync(i => i.Id == demonId);
        }

        /// <summary>
        /// method to get all Demons in the backend and return a list of demons
        /// </summary>
        /// <returns>a list of Demons</returns>
        public async Task<IEnumerable<DDStoryMegaTen>> GetAllDemonsAsync()

        {
            return await _ctx.DDSMTDemons.ToListAsync();
        }


        /// <summary>
        /// Adds a demon to the database.
        /// </summary>
        /// <param name="demon"></param>
        /// <returns>Demon</returns>

        public async Task<DDStoryMegaTen> CreateDemonAsync(DDStoryMegaTen demon)
        {
            _ctx.DDSMTDemons.Add(demon);
            await _ctx.SaveChangesAsync();

            return demon;
        }

        /// <summary>
        /// Updates a Demon
        /// </summary>
        /// <param name="updatedDemon">Demon to be updated</param>
        /// <returns>Demon</returns>

        public async Task<DDStoryMegaTen> UpdateDDStoryMegaTenAsync(DDStoryMegaTen updatedDemon)
        {
            _ctx.DDSMTDemons.Update(updatedDemon);
            await _ctx.SaveChangesAsync();

            return updatedDemon;
        }

        /// <summary>
        /// This method deletes a Demon
        /// </summary>
        /// <param name="demon">demon to be deleted</param>
        public async Task DeleteDemonAsync(DDStoryMegaTen demon)
        {
            _ctx.DDSMTDemons.Remove(demon);
            await _ctx.SaveChangesAsync();
        }

    }

}
