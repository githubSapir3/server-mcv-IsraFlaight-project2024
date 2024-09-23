namespace mcv_project2024.DO
{

    public class AirplaneDto
    {
        public required string Manufacturer { get; set; }
        public required string Nickname { get; set; }
        public int YearOfManufacture { get; set; }
        public required string ImageUrl { get; set; }
    }
}