using CateringCo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CateringCo
{
    public class CateringCoContext : IdentityDbContext/*<IdentityUser>*/
    {
        public CateringCoContext(DbContextOptions<CateringCoContext> options)
            : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        public DbSet<Locations> Locations => Set<Locations>();
        //public DbSet<Locations> Locations { get; set; } = null!;
        //public DbSet<MenuItem> MenuItems { get; set; } = null!;
    }
}