using Shin.Megami.Tensei.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for Persona5Royal related service methods.
    /// </summary>
    public interface IP5RProvider
    {
        Task<Persona5Royal> GetPersonaByIdAsync(int personaId);

        Task<IEnumerable<Persona5Royal>> GetAllPersonaAsync();

        Task<Persona5Royal> CreatePersonaAsync(Persona5Royal newPersona);

        Task<Persona5Royal> UpdatePersonaAsync(int personaId, Persona5Royal updatedPersona);

        Task DeletePersonaByIdAsync(int personaId);

    }
}
