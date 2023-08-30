using AdoptiverseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptiverseAPI.DataAccess
{
    public class AdoptiverseApiContext : DbContext
    {
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public AdoptiverseApiContext(DbContextOptions<AdoptiverseApiContext> options) : base(options)
        {
            
        }
    }
}
