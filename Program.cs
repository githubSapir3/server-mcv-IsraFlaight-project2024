using Microsoft.EntityFrameworkCore;
using DB;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
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
      //  builder.Services.AddScoped<UserService>();
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