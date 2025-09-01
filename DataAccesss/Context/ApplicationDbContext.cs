using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    /// <summary>
    /// Энэхүү класс нь нислэг, зорчигч, захиалгын мэдээллийг хадгалах, удирдах зориулалттай өгөгдлийн сангийн контекст юм.
    /// PassportNumber талбарт давхардалгүй индекс үүсгэж, Reservation нь Flight болон Passenger класстай гадаад түлхүүрээр холбогддог.
    /// </summary>
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique constraint for Passport
            modelBuilder.Entity<Passenger>()
                .HasIndex(p => p.PassportNumber)
                .IsUnique();

            // Reservation relations
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Flight)
                .WithMany()
                .HasForeignKey(r => r.FlightId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Passenger)
                .WithMany()
                .HasForeignKey(r => r.PassengerId);
        }
    }
}
