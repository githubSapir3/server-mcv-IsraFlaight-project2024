using mcv_project2024.Models;

public class BookingService : IApiService<Booking>
{
    private readonly List<Booking> _bookings = new List<Booking>(); // אחסון זמני ברשימה

    public async Task<Booking> AddAsync(Booking booking)
    {
        _bookings.Add(booking);
        return await Task.FromResult(booking);
    }

    
    public async Task<Booking> GetByIdAsync(int id)
    {
        var booking = _bookings.Find(b => b.bookingID == id);
        return await Task.FromResult(booking);
    }

    
    public async Task<Booking> UpdateAsync(int id, Booking updatedBooking)
    {
        var booking = _bookings.Find(b => b.bookingID == id);
        if (booking != null)
        {
            // עדכון ההזמנה
            booking.passengerID = updatedBooking.passengerID;
            booking.Flight = updatedBooking.Flight;
        }
        return await Task.FromResult(booking);
    }

   
    public async Task<bool> DeleteAsync(int id)
    {
        var booking = _bookings.Find(b => b.bookingID == id);
        if (booking != null)
        {
            _bookings.Remove(booking);
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }

    // שליפת כל ההזמנות
    public async Task<List<Booking>> GetAllAsync()
    {
        return await Task.FromResult(_bookings);
    }
}
