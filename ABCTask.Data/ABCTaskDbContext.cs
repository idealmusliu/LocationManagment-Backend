using ABCTask.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ABCTask.Data
{
    public class ABCTaskDbContext : IdentityDbContext
    {
        public ABCTaskDbContext(DbContextOptions<ABCTaskDbContext> options) : base(options)
        {

        }

        //dbsets

        public DbSet<City> City { get; set; }
        public DbSet<Location> Location { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>()
                .HasOne(b => b.City)
                .WithMany(i => i.Locations)
                .HasForeignKey(b => b.CityId);
        }
    }
}
