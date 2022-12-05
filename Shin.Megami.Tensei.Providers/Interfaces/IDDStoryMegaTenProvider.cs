using Shin.Megami.Tensei.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for DDStoryMegaTen related service methods.
    /// </summary>
    public interface IDDStoryMegaTenProvider
    {
        Task<DDStoryMegaTen> GetDemonByIdAsync(int demonId);

        Task<IEnumerable<DDStoryMegaTen>> GetAllDemonsAsync();

        Task<DDStoryMegaTen> CreateDemonAsync(DDStoryMegaTen demon);

        Task<DDStoryMegaTen> UpdateDemonAsync(int demonId, DDStoryMegaTen updatedDemon);

        Task DeleteDemonByIdAsync(int demonId);

    }
}
