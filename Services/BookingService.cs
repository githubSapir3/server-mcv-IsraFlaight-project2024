using DB;
using Microsoft.EntityFrameworkCore;
using mcv_project2024.DAL;
using mcv_project2024.Services;

public class BookingService : IApiService<Booking>
{
    private readonly ApplicationDbContext _context; // Database context

    public BookingService(ApplicationDbContext context)
    {
        _context = context; // Injecting DbContext
    }

    // Create a new booking
    public async Task<Booking> CreateBookingAsync(int passengerId, int flightId)
    {
        Flight flight = await _context.Flights.FindAsync(flightId); // Use EF to find flight
        if (flight == null)
        {
            throw new ArgumentException("Flight not found.");
        }

        Booking booking = new Booking(passengerId, flightId);
        booking.Flight = flight;
        return booking;
    }

    // Add booking to database
    public async Task<Booking> AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking); // Adding booking to DB
        await _context.SaveChangesAsync(); // Save changes
        return booking;
    }

    // Get booking by ID
    public async Task<Booking> GetByIdAsync(int id)
    {
        return await _context.Bookings
            .Include(b => b.Flight) // Include related Flight entity
            .FirstOrDefaultAsync(b => b.BookingID == id);
    }

    // Update an existing booking
    public async Task<Booking> UpdateAsync(int id, Booking updatedBooking)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking != null)
        {
            booking.PassengerID = updatedBooking.PassengerID;
            booking.Flight = updatedBooking.Flight;

            _context.Bookings.Update(booking); // Mark booking as updated
            await _context.SaveChangesAsync();
            return booking;
        }
        return null;
    }

    // Delete a booking
    public async Task<bool> DeleteAsync(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking != null)
        {
            _context.Bookings.Remove(booking); // Remove booking
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    // Get all bookings
    public async Task<List<Booking>> GetAllAsync()
    {
        return await _context.Bookings
            .Include(b => b.Flight) // Include related Flight entity
            .ToListAsync(); // Retrieve all bookings
    }
}
