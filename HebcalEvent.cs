public class HebcalResponse
{
    public string Title { get; set; }
    public string Date { get; set; }
    public Location Location { get; set; }
    public Range Range { get; set; }
    public List<Item> Items { get; set; }
}

public class Location
{
    public string Title { get; set; }
    public string City { get; set; }
    public string Tzid { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Cc { get; set; }
    public string Country { get; set; }
    public string Admin1 { get; set; }
    public string Asciiname { get; set; }
    public string Geo { get; set; }
    public int Geonameid { get; set; }
}

public class Range
{
    public string Start { get; set; }
    public string End { get; set; }
}

public class Item
{
    public string Title { get; set; }
    public string Date { get; set; }
    public string Category { get; set; }
    public string Title_orig { get; set; }
    public string Hebrew { get; set; }
    public string Memo { get; set; }
    public Leyning Leyning { get; set; }
    public string Hdate { get; set; }
    public bool Yomtov { get; set; }
    public string Subcat { get; set; }
    public string Link { get; set; }
}

public class Leyning
{
    public Dictionary<string, string> Triennial { get; set; }
    public string Torah { get; set; }
    public string Haftarah { get; set; }
    public string Maftir { get; set; }
}
