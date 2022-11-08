using Shin.Megami.Tensei.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Shin.Megami.Tensei.Data.Context
{
    /// <summary>
    /// SMT Franchise Demons database context provider.
    /// </summary>
    public class SMTCtx : DbContext, ISMTCtx
    {

        public SMTCtx(DbContextOptions<SMTCtx> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Encounter> Encounters { get; set; }

        public DbSet<MegaTen> MTDemons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
