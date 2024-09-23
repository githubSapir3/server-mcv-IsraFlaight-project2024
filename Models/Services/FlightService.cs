using mcv_project2024.Models;
using mcv_project2024.Models.Services;
using Microsoft.AspNetCore.Mvc;

public class FlightService : IApiService<Flight>
    {
        private List<Flight> _flights = new List<Flight>();

        public async Task<Flight> AddAsync(Flight item)
        {
            // Simulating asynchronous operation
            await Task.Run(() => _flights.Add(item));
            return item;
        }

        public async Task<Flight> CreateAsync(string departureLocation, string arrivalLocation, int airplaneId, DateTime departureTime, DateTime arrivalTime)
        {
            // Generate a new Flight object with default values (for Id, etc.)
            var newFlight = new Flight(
                airplaneId: airplaneId,
                departureLocation: departureLocation,
                arrivalLocation: arrivalLocation,
                departureTime: departureTime,
                arrivalTime: arrivalTime
            );

            await AddAsync(newFlight);
            return newFlight;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var flight = _flights.FirstOrDefault(f => f.Id == id);
            if (flight != null)
            {
                await Task.Run(() => _flights.Remove(flight));
                return true;
            }
            return false;
        }

        public async Task<List<Flight>> GetAllAsync()
        {
            // Return all flights
            return await Task.Run(() => _flights.ToList());
        }

        public async Task<Flight> GetByIdAsync(int id)
        {
            // Find the flight by id
            return await Task.Run(() => _flights.FirstOrDefault(f => f.Id == id));
        }

    

        public async Task<Flight> UpdateAsync(int id, Flight item)
        {
            var flight = _flights.FirstOrDefault(f => f.Id == id);
            if (flight != null)
            {
                flight.Airplane = item.Airplane;
                flight.DepartureLocation = item.DepartureLocation;
                flight.ArrivalLocation = item.ArrivalLocation;
                flight.DepartureTime = item.DepartureTime;
                flight.ArrivalTime = item.ArrivalTime;

                await Task.Run(() => { /* Simulate update */ });
                return flight;
            }
            return null;
        }
    }
