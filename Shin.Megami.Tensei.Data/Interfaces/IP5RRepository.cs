using Shin.Megami.Tensei.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for Persona5Royal repository methods.
    /// </summary>
    public interface IP5RRepository
    {
        Task<Persona5Royal> GetPersonaByIdAsync(int personaId);

        Task<IEnumerable<Persona5Royal>> GetAllPersonasAsync();

        Task<Persona5Royal> CreatePersonaAsync(Persona5Royal persona);

        Task<Persona5Royal> UpdatePersonaAsync(Persona5Royal updatedPersona);

        Task DeletePersonaAsync(Persona5Royal persona);
    }
}
