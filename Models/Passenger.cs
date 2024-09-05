// Models/Passenger.cs

using System.Collections.Generic;



    public class Passenger : User
    {
        public List<Flight> Flights { get; set; }

        public Passenger(int id, string fullName, string email, string password)
            : base(id, fullName, email, password)
        {
            Flights = new List<Flight>();
        }

        public void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }

        public List<Flight> GetFlights()
        {
            return Flights;
        }
    }

