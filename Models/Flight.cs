// Models/Flight.cs

using System;
    public class Flight
    {
        public int Id { get; set; }
        public required Plane Plane { get; set; } // Assuming Aircraft is another class in your project
        public required string DepartureLocation { get; set; }
        public required string ArrivalLocation { get; set; }
        public required DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Flight(){}
        public Flight(int id, Plane plane, string departureLocation, string arrivalLocation, DateTime departureTime, DateTime arrivalTime)
        {
            Id = id;
            Plane = plane;
            DepartureLocation = departureLocation;
            ArrivalLocation = arrivalLocation;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
        }

        public TimeSpan GetFlightDuration()
        {
            return ArrivalTime - DepartureTime;
        }
    }

