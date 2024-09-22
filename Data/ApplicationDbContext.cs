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
        public DbSet<Plane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Plane>().ToTable("Airplanes");
            modelBuilder.Entity<Flight>().ToTable("Flights");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Booking>().ToTable("Bookings");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            

            
        }
    }
}
