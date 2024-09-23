using mcv_project2024.Models;
using System.Net.Sockets;
using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for entities
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Airplane>().ToTable("Airplanes");
            modelBuilder.Entity<Flight>().ToTable("Flights");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Booking>().ToTable("Bookings");

        }
    }
}