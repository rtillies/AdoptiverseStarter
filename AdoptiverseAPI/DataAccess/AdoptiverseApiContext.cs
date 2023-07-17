using Microsoft.EntityFrameworkCore;

namespace AdoptiverseAPI.DataAccess
{
    public class AdoptiverseApiContext : DbContext
    {
        public AdoptiverseApiContext(DbContextOptions<AdoptiverseApiContext> options) : base(options)
        {
            
        }
    }
}
