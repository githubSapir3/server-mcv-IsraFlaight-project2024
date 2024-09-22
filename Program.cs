using Microsoft.EntityFrameworkCore; // שימוש ב-EF Core
using DB; // ייבוא של קבצי ה-DB (בהנחה שכבר קיים)

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// הגדרת HttpClient עם כתובת ה-API שלך
builder.Services.AddHttpClient("ApiClient", client =>
{
    // הגדרת בסיס הכתובת של ה-API שלך
    client.BaseAddress = new Uri("https://localhost:7292");
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
