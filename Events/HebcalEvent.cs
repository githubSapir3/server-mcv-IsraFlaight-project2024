public class HebcalResponse
{
    public required Location Location { get; set; }
    public required List<Item> Items { get; set; }
    public required Range range { get; set; }
    
}

public class Location
{
    public required string City { get; set; } 
    public required string Country { get; set; }
}

public class Range
{
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; } 
}

public class Item
{
    public required string Title { get; set; } 
    public required DateTime Date { get; set; } 
    public required string Category { get; set; }
}

