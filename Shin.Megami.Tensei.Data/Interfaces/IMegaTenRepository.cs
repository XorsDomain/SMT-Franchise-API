using Shin.Megami.Tensei.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for MegaTen repository methods.
    /// </summary>
    public interface IMegaTenRepository
    {
        Task<MegaTen> GetMegaTenByIdAsync(int MegaTenId);

        Task<IEnumerable<MegaTen>> GetAllMegaTensAsync();

        Task<MegaTen> CreateMegaTenAsync(MegaTen MegaTen);

        Task<MegaTen> UpdateMegaTenAsync(MegaTen updatedMegaTen);

        Task DeleteMegaTenAsync(MegaTen MegaTen);
    }
}
