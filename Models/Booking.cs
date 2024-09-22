
namespace mcv_project2024.Models
{
    public class Booking
    {
        public int bookingID { get; set; } // מפתח ראשי
        public int passengerID { get; set; }
        public required Flight flight { get; set; }

        public Booking(int passengerId, Flight flight)
        {
            this.passengerID = passengerId;
            this.flight = flight;
        }
    }
}