using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Энэ нь зөв ажиллана
            modelBuilder.Entity<Flight>().ToTable("Flights");
        }
    }
}
