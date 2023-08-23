

using AeCAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace AeCAPI.Data
{
    public class AeCContext :DbContext
    {
        public AeCContext(DbContextOptions<AeCContext> opts) :base (opts) { }

        public DbSet<Aeroportos> aeroporto { get; set; }
        public DbSet<Cidades> cidades { get; set; }
        public DbSet<Clima> climas { get; set; }
        public DbSet<log> logs { get; set; }


    }
}
