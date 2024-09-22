
using System.Threading.Tasks;



public class Booking
{
    public int bookingID { get; set; } // מפתח ראשי
    public int passengerID { get; set; }
    public required Flight Flight { get; set; }

    
    public Booking(int passengerId, int flightNum)
    {
        this.passengerID = passengerId;
        this.Flight = FlightService.GetGetByIdAsync(flightId).Result;

    }
    

}
