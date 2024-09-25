using System;
using System.Collections.Generic;

namespace mcv_project2024.Module.DAL
{
    public class Flight
    {
        public int FlightId { get; set; }
        public int AirplaneId { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

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
