using Shin.Megami.Tensei.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for Encounter repository methods.
    /// </summary>
    public interface IEncounterRepository
    {
        Task<Encounter> GetEncounterByIdAsync(int encounterId);

        Task<IEnumerable<Encounter>> GetAllEncountersAsync();

        Task<Encounter> CreateEncounterAsync(Encounter encounter);

        Task<Encounter> UpdateEncounterAsync(Encounter updatedEncounter);

        Task DeleteEncounterAsync(Encounter encounter);
    }
}
