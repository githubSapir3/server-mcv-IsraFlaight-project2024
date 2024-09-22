// Class representing the structure of the response from the Imagga API.
public class ImaggaResponse
{
    public required Result Result { get; set; }
}

// Class representing the result from the API, containing a list of tags.
public class Result
{
    public required List<Tag> Tags { get; set; }
}

// Class representing a single tag with a confidence level and the tag name.
public class Tag
{
    public double Confidence { get; set; }
    public required string TagName { get; set; }
}
