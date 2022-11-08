using Shin.Megami.Tensei.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for encounter related service methods.
    /// </summary>
    public interface IEncounterProvider
    {
        Task<Encounter> GetEncounterByIdAsync(int encounterId);

        Task<IEnumerable<Encounter>> GetAllEncountersAsync();

        Task<Encounter> CreateEncounterAsync(Encounter encounter);

        Task<Encounter> UpdateEncounterAsync(int encounterId, Encounter updatedEncounter);

        Task DeleteEncounterByIdAsync(int encounterId);

    }
}
