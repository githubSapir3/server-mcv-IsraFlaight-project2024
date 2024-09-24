using DB;
using Microsoft.EntityFrameworkCore;
using mcv_project2024.DO;
using mcv_project2024.Module.Services;
using mcv_project2024.Module.DAL;

public class BookingService
{
    private readonly ApplicationDbContext _context; // Database context

    public BookingService(ApplicationDbContext context)
    {
        _context = context; // Injecting DbContext
    }


    public async Task<BookingDto> GetByIdAsync(int id)
    {
        var bookingWithFlight = await (from booking in _context.Bookings
                                       join flight in _context.Flights
                                       on booking.FlightId equals flight.FlightId
                                       where booking.BookingID == id
                                       select new BookingDto
                                       {
                                           BookingID = booking.BookingID,
                                           PassengerID = booking.PassengerID,
                                           FlightId = booking.FlightId,
                                           FlightNumber = flight.FlightId // להחזיר את מספר הטיסה
                                       }).FirstOrDefaultAsync();

        return bookingWithFlight;
    }

    public async Task<List<BookingDto>> GetAllAsync()
    {
        var bookingsWithFlights = await (from booking in _context.Bookings
                                         join flight in _context.Flights
                                         on booking.FlightId equals flight.FlightId
                                         select new BookingDto
                                         {
                                             BookingID = booking.BookingID,
                                             PassengerID = booking.PassengerID,
                                             FlightId = booking.FlightId,
                                             FlightNumber = flight.FlightId
                                         }).ToListAsync();

        return bookingsWithFlights;
    }

    // Create a new booking
    public async Task<Booking> CreateAsync(int passengerId, int flightId)
    {
        Booking booking = new Booking(passengerId, flightId);
        return booking;
    }

    // Add booking to database
    public async Task<Booking> AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking); // Adding booking to DB
        await _context.SaveChangesAsync(); // Save changes
        return booking;
    }

    // Update an existing booking
    public async Task<Booking> UpdateAsync(int id, Booking updatedBooking)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking != null)
        {
            booking.PassengerID = updatedBooking.PassengerID;

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

    internal async Task<List<BookingDto>> GetByPassengerIdAsync(int passenger_id)
    {
        var bookingsWithFlights = await (from booking in _context.Bookings
                                         join flight in _context.Flights
                                         on booking.FlightId equals flight.FlightId
                                         where booking.PassengerID == passenger_id
                                         select new BookingDto
                                         {
                                             BookingID = booking.BookingID,
                                             PassengerID = booking.PassengerID,
                                             FlightId = booking.FlightId,
                                             FlightNumber = flight.FlightId
                                         }).ToListAsync();

        return bookingsWithFlights;
    }
}
