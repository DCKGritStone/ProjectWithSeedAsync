using Microsoft.EntityFrameworkCore;
using ProjectWithSeedAsync.Domain.Entity;

namespace ProjectWithSeedAsync.Infrastructure.Data
{
    public class CityStateCountryDbContext : DbContext
    {
        public CityStateCountryDbContext(DbContextOptions<CityStateCountryDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
