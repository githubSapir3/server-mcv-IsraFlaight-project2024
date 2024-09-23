
namespace mcv_project2024.Models
{
    public class Airplane

    {
        public int AirplaneId { get; set; }
        public string Manufacturer { get; set; }
        public string Nickname { get; set; }
        public int YearOfManufacture { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Flight> Flights { get; set; } = new List<Flight>();

        public Airplane(string manufacturer, string nickname, int yearOfManufacture, string imageUrl)
        {
            Manufacturer = manufacturer;
            Nickname = nickname;
            YearOfManufacture = yearOfManufacture;
            ImageUrl = imageUrl;
        }

        public Airplane() { }
    }
}