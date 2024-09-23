using System;
using System.Collections.Generic;

namespace mcv_project2024.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        // Keep this as the correct definition
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public Flight(int airplaneId, string departureLocation, string arrivalLocation, DateTime departureTime, DateTime arrivalTime)
        {
            AirplaneId = airplaneId;
            DepartureLocation = departureLocation;
            ArrivalLocation = arrivalLocation;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
        }

        public Flight() { }

        public TimeSpan GetFlightDuration()
        {
            return ArrivalTime - DepartureTime;
        }
    }
}
