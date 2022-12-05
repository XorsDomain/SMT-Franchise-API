using Shin.Megami.Tensei.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for DDStoryMegaTen repository methods.
    /// </summary>
    public interface IDDStoryMegaTenRepository
    {
        Task<DDStoryMegaTen> GetDemonByIdAsync(int demonId);

        Task<IEnumerable<DDStoryMegaTen>> GetAllDemonsAsync();

        Task<DDStoryMegaTen> CreateDemonAsync(DDStoryMegaTen demon);

        Task<DDStoryMegaTen> UpdateDDStoryMegaTenAsync(DDStoryMegaTen updatedDemon);

        Task DeleteDemonAsync(DDStoryMegaTen demon);
    }
}
