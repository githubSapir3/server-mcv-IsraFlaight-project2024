namespace mcv_project2024.Module.DAL
{
    public class Booking
    {
        public int BookingID { get; set; } // מפתח ראשי
        public int PassengerID { get; set; } // מזהה נוסע
        public int FlightId { get; set; } // מפתח זר ל-Flight

        public Booking(int passengerId, int flightId)
        {
            PassengerID = passengerId; // השתמש במאפיינים ב-CamelCase
            FlightId = flightId;
        }

        // קונסטרוקטור ברירת מחדל
        public Booking() { }
    }
}
