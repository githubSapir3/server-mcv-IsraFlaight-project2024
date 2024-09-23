using mcv_project2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class FlightService
{
    private List<Flight> _flights = new List<Flight>();

    public async Task<Flight> AddAsync(Flight item)
    {
        await Task.Run(() => _flights.Add(item));
        return item;
    }

    public async Task<Flight> CreateAsync(string departureLocation, string arrivalLocation, int airplaneId, DateTime departureTime, DateTime arrivalTime)
    {
        var newFlight = new Flight
        {
            AirplaneId = airplaneId,
            DepartureLocation = departureLocation,
            ArrivalLocation = arrivalLocation,
            DepartureTime = departureTime,
            ArrivalTime = arrivalTime
        };

        await AddAsync(newFlight);
        return newFlight;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var flight = _flights.FirstOrDefault(f => f.FlightId == id);
        if (flight != null)
        {
            await Task.Run(() => _flights.Remove(flight));
            return true;
        }
        return false;
    }

    public async Task<List<Flight>> GetAllAsync()
    {
        return await Task.Run(() => _flights.ToList());
    }

    public async Task<Flight> GetByIdAsync(int id)
    {
        return await Task.Run(() => _flights.FirstOrDefault(f => f.FlightId == id));
    }

    public async Task<Flight> UpdateAsync(int id, Flight item)
    {
        var flight = _flights.FirstOrDefault(f => f.FlightId == id);
        if (flight != null)
        {
            flight.Airplane = item.Airplane;
            flight.DepartureLocation = item.DepartureLocation;
            flight.ArrivalLocation = item.ArrivalLocation;
            flight.DepartureTime = item.DepartureTime;
            flight.ArrivalTime = item.ArrivalTime;

            await Task.Run(() => { });
            return flight;
        }
        return null;
    }
}
