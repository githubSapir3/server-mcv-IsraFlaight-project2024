namespace mcv_project2024.DAL
{
    public class Booking
    {
        public int BookingID { get; set; } // מפתח ראשי
        public int PassengerID { get; set; } // מזהה נוסע
        public int FlightId { get; set; } // מפתח זר ל-Flight
        public Flight Flight { get; set; } // קשר לטיסה

        public Booking(int passengerId, int flightId)
        {
            PassengerID = passengerId; // השתמש במאפיינים ב-CamelCase
            FlightId = flightId;
        }

        // קונסטרוקטור ברירת מחדל
        public Booking() { }
    }
}
