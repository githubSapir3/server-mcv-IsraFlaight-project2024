// Models/Plane.cs


    public class Plane
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Nickname { get; set; }
        public int YearOfManufacture { get; set; }
        public string ImageUrl { get; set; }

        public Plane(int id, string manufacturer, string nickname, int yearOfManufacture, string imageUrl )
        {
            Id = id;
            Manufacturer = manufacturer;
            Nickname = nickname;
            YearOfManufacture = yearOfManufacture;
            ImageUrl = imageUrl;
        }
    }

