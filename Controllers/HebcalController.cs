
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


[ApiController]
[Route("[controller]")]
public class HebcalController : ControllerBase
{
    private readonly HttpClient _httpClient;
    

    public HebcalController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        string url = "https://www.hebcal.com/hebcal?v=1&cfg=json&maj=on&min=on&mod=on&nx=on&year=now&month=x&ss=on&mf=on&c=on&geo=geoname&geonameid=3448439&M=on&s=on";

        try
        {
            var response = await _httpClient.GetStringAsync(url);
            var hebcalData = JsonConvert.DeserializeObject<HebcalResponse>(response);

            if (hebcalData?.Items == null)
            {
                return BadRequest("Failed to parse Hebcal data or Items is null.");
            }

            return Ok(hebcalData);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("byDateAndLocation")]
public async Task<IActionResult> GetByDateAndLocation(string location, string date)
{
    if (string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(date))
    {
        return BadRequest("Both location and date parameters are required.");
    }

    string url = $"https://www.hebcal.com/hebcal?v=1&cfg=json&geo=city&city={Uri.EscapeDataString(location)}&date={Uri.EscapeDataString(date)}&ss=on&M=on";

    try
    {
        var response = await _httpClient.GetStringAsync(url);
        var hebcalData = JsonConvert.DeserializeObject<HebcalResponse>(response);

        if (hebcalData?.Items == null)
        {
            return BadRequest("Failed to parse Hebcal data or Items is null.");
        }

        return Ok(hebcalData);
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Internal server error: {ex.Message}");
    }
}

}
