using Hangar.Dao.AirCraft;
using Hangar.Dao.Hangar;
using Microsoft.EntityFrameworkCore;

namespace Hangar.Dao
{
    public class HangarContext : DbContext
    {
        public DbSet<HangarDto> Hangars { get; set; }
        public DbSet<AirCraftDto> AirCrafts { get; set; }
        public HangarContext(DbContextOptions<HangarContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
    }
}