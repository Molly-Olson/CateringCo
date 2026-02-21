using Microsoft.EntityFrameworkCore;

namespace CateringCo.Models
{
    public class CateringCoContext : DbContext
    {
        public CateringCoContext(DbContextOptions<CateringCoContext> options)
            : base(options)
        {
        }
        public DbSet<Locations> Locations => Set<Locations>();
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        // public DbSet<Orders> Orders => Set<Orders>();
    }
}
