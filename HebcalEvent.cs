public class HebcalResponse
{
    public required string Title { get; set; }
    public required string Date { get; set; }
    public required Location Location { get; set; }
    public required Range Range { get; set; }
    public required List<Item> Items { get; set; }
}

public class Location
{
    public required string Title { get; set; }
    public required string City { get; set; }
    public required string Tzid { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public required string Cc { get; set; }
    public required string Country { get; set; }
    public required string Admin1 { get; set; }
    public required string Asciiname { get; set; }
    public required string Geo { get; set; }
    public int Geonameid { get; set; }
}

public class Range
{
    public required string Start { get; set; }
    public required string End { get; set; }
}

public class Item
{
    public required string Title { get; set; }
    public required string Date { get; set; }
    public required string Category { get; set; }
    public required string Title_orig { get; set; }
    public required string Hebrew { get; set; }
    public required string Memo { get; set; }
    public required Leyning Leyning { get; set; }
    public required string Hdate { get; set; }
    public bool Yomtov { get; set; }
    public required string Subcat { get; set; }
    public required string Link { get; set; }
}

public class Leyning
{
    public required Dictionary<string, string> Triennial { get; set; }
    public required string Torah { get; set; }
    public required string Haftarah { get; set; }
    public required string Maftir { get; set; }
}
