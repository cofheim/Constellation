using Constellation.Persistence.Configurations.UserConfigurations;
using Constellation.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Constellation.Persistence
{
    public class ConstellationDbContext : DbContext
    {
        public ConstellationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PhotoEntity> Photos { get; set; }
        public DbSet<MasterClassEntity> MasterClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
