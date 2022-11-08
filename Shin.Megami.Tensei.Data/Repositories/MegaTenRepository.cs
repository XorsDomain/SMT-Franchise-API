using Shin.Megami.Tensei.Data.Context;
using Shin.Megami.Tensei.Data.Interfaces;
using Shin.Megami.Tensei.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the MegaTen repository.
    /// </summary>
    public class MegaTenRepository : IMegaTenRepository
    {
        private readonly ISMTCtx _ctx;

        public MegaTenRepository(ISMTCtx ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// This method gets a MegaTen by its id.
        /// </summary>
        /// <param name="MegaTenId"></param>
        /// <returns>MegaTen by given ID</returns>
        public async Task<MegaTen> GetMegaTenByIdAsync(int MegaTenId)
        {
            return await _ctx.MegaTens.AsNoTracking().FirstOrDefaultAsync(i => i.Id == MegaTenId);
        }

        /// <summary>
        /// method to get all MegaTens in the backend and return a list of MegaTens
        /// </summary>
        /// <returns>a list of MegaTens</returns>
        public async Task<IEnumerable<MegaTen>> GetAllMegaTensAsync()

        {
            return await _ctx.MegaTens.ToListAsync();
        }


        /// <summary>
        /// Adds a MegaTen to the database.
        /// </summary>
        /// <param name="MegaTen"></param>
        /// <returns>MegaTen</returns>

        public async Task<MegaTen> CreateMegaTenAsync(MegaTen MegaTen)
        {
            _ctx.MegaTens.Add(MegaTen);
            await _ctx.SaveChangesAsync();

            return MegaTen;
        }

        /// <summary>
        /// Updates a MegaTen
        /// </summary>
        /// <param name="MegaTen">MegaTen to be updated</param>
        /// <returns>MegaTen</returns>

        public async Task<MegaTen> UpdateMegaTenAsync(MegaTen updatedMegaTen)
        {
            _ctx.MegaTens.Update(updatedMegaTen);
            await _ctx.SaveChangesAsync();

            return updatedMegaTen;
        }

        /// <summary>
        /// This method deletes a MegaTen
        /// </summary>
        /// <param name="MegaTen">MegaTen to be deleted</param>
        public async Task DeleteMegaTenAsync(MegaTen MegaTen)
        {
            _ctx.MegaTens.Remove(MegaTen);
            await _ctx.SaveChangesAsync();
        }

    }

}
