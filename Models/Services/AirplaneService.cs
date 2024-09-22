using DB;
using mcv_project2024.Models.Services;
using Microsoft.EntityFrameworkCore;
using mcv_project2024.Models;

public class AirplaneService : IApiService<Airplane>
{
    private readonly ApplicationDbContext _context;

    public AirplaneService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Airplane> AddAsync(Airplane airplane)
    {
        _context.Airplanes.Add(airplane);
        await _context.SaveChangesAsync();
        return airplane;
    }

    public async Task<Airplane> CreateAsync(string manufacturer, string nickname, int yearOfManufacture, string imageUrl)
    {
        var newPlane = new Airplane(manufacturer, nickname, yearOfManufacture, imageUrl); // הוספת הפרמטרים לקונסטרוקטור
        await AddAsync(newPlane); // הוספת המטוס למאגר הנתונים
        return newPlane;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var plane = await _context.Airplanes.FindAsync(id);
        if (plane != null)
        {
            _context.Airplanes.Remove(plane);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<Airplane>> GetAllAsync()
    {
        return await _context.Airplanes.ToListAsync();
    }

    public async Task<Airplane> GetByIdAsync(int id)
    {
        return await _context.Airplanes.FindAsync(id);
    }

    public async Task<Airplane> UpdateAsync(int id, Airplane item)
    {
        var existingPlane = await _context.Airplanes.FindAsync(id);
        if (existingPlane != null)
        {
            existingPlane.Manufacturer = item.Manufacturer;
            existingPlane.Nickname = item.Nickname;
            existingPlane.YearOfManufacture = item.YearOfManufacture;
            existingPlane.ImageUrl = item.ImageUrl;

            await _context.SaveChangesAsync();
            return existingPlane;
        }
        return null;
    }

   
}
