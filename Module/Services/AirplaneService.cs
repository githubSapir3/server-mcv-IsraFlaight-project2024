using DB;
using Microsoft.EntityFrameworkCore;
using mcv_project2024.Module.Services;
using mcv_project2024.Module.DAL;

public class AirplaneService : IApiService<Airplane>
{
    private readonly ApplicationDbContext _context;

    public AirplaneService(ApplicationDbContext context)
    {
        _context = context;
    }

    public object Users { get; internal set; }

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
#pragma warning disable CS8603 // Possible null reference return.
        return await _context.Airplanes.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
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

    internal async Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
