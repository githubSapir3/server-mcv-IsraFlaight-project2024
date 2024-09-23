namespace mcv_project2024.DO
{
    public class FlightDto
    {
        public required string DepartureLocation { get; set; }
        public required string ArrivalLocation { get; set; }
        public required int AirplaneId { get; set; }
        public required DateTime DepartureTime { get; set; }
        public required DateTime ArrivalTime { get; set; }
    }

}
