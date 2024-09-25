using DB;
using mcv_project2024.Module.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class FlightService
{
    private readonly ApplicationDbContext _context;

    public FlightService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Function to add a flight
    public async Task<Flight> AddAsync(Flight flight)
    {
        await _context.Flights.AddAsync(flight);
        await _context.SaveChangesAsync();
        return flight;
    }

    // Function to create a new flight
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

        return await AddAsync(newFlight);
    }

    // Function to delete a flight
    public async Task<bool> DeleteAsync(int id)
    {
        var flight = await _context.Flights.FindAsync(id);
        if (flight != null)
        {
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    // Function to get all flights
    public async Task<List<Flight>> GetAllAsync()
    {
        return await _context.Flights.ToListAsync();
    }

    // Function to get a flight by ID
    public async Task<Flight> GetByIdAsync(int id)
    {
        return await _context.Flights.FindAsync(id);
    }

    // Function to update a flight
    public async Task<bool> UpdateAsync(int id, Flight updatedFlight)
    {
        var flight = await _context.Flights.FindAsync(id);
        if (flight != null)
        {
            flight.AirplaneId = updatedFlight.AirplaneId;
            flight.DepartureLocation = updatedFlight.DepartureLocation;
            flight.ArrivalLocation = updatedFlight.ArrivalLocation;
            flight.DepartureTime = updatedFlight.DepartureTime;
            flight.ArrivalTime = updatedFlight.ArrivalTime;

            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<Flight>> GetLandingFlightsInTLVAsync(DateTime currentTime, DateTime endTime)
    {
    return await _context.Flights
        .Where(flight => flight.ArrivalLocation == "Tel Aviv" && flight.ArrivalTime >= currentTime && flight.ArrivalTime <= endTime)
        .ToListAsync();
    }

    
}
