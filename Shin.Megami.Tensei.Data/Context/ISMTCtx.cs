using Shin.Megami.Tensei.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Data.Context
{
    /// <summary>
    /// This interface provides an abstraction layer for the SMT Franchise database context.
    /// </summary>
    public interface ISMTCtx
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<Encounter> Encounters { get; set; }

        public DbSet<DDStoryMegaTen> DDSMTDemons { get; set; }

        public DbSet<Persona5Royal> P5RPersonas { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

}
