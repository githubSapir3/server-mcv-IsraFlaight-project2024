// Services/BookingService.cs

using System.Threading.Tasks;


    public interface IApiService
    {
        Task<Booking> CreateBookingAsync(BookingData bookingData);
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task<Booking> UpdateBookingAsync(int bookingId, BookingData updatedData);
        Task<bool> CancelBookingAsync(int bookingId);
    }
    
    public class Booking
{
    public int Id { get; set; } // מפתח ראשי

    
    public string? BookingDetails { get; set; }
}

    public class BookingService
    {
        private readonly IApiService _apiService;

        public BookingService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<Booking> CreateBookingAsync(BookingData bookingData)
        {
            return await _apiService.CreateBookingAsync(bookingData);
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            return await _apiService.GetBookingByIdAsync(bookingId);
        }

        public async Task<Booking> UpdateBookingAsync(int bookingId, BookingData updatedData)
        {
            return await _apiService.UpdateBookingAsync(bookingId, updatedData);
        }

        public async Task<bool> CancelBookingAsync(int bookingId)
        {
            return await _apiService.CancelBookingAsync(bookingId);
        }
    }

    // Assuming BookingData is a class representing the data structure for booking
    public class BookingData
    {
        // Define properties for booking data here
    }

    // Assuming Booking is a class representing the booking entity
    

