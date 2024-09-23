using Microsoft.EntityFrameworkCore;
using DB;
using mcv_project2024.Models.Services;
using mcv_project2024.Models; // ייבוא של המודלים שלך

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<DB.ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // הגדרת HttpClient עם כתובת ה-API שלך
        builder.Services.AddHttpClient("ApiClient", client =>
        {
            // הגדרת בסיס הכתובת של ה-API שלך
            client.BaseAddress = new Uri("https://localhost:7292");
        });

        // רישום של השירותים שלך
        builder.Services.AddScoped<BookingService>(); // רישום של BookingService
        builder.Services.AddScoped<FlightService>();  // רישום של FlightService
        builder.Services.AddScoped<AirplaneService>();  // רישום של PlaneService

        builder.Services.AddControllers();

                 builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}