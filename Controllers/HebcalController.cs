﻿
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



    [HttpGet("GetByDateAndLocationInRange")]
    public async Task<IActionResult> GetByDateAndLocationInRange(string location, string startDate, string endDate)
    {
        if (string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(startDate) || string.IsNullOrWhiteSpace(endDate))
        {
            return BadRequest("Location, startDate, and endDate parameters are required.");
        }

        DateTime start;
        DateTime end;
        if (!DateTime.TryParse(startDate, out start) || !DateTime.TryParse(endDate, out end))
        {
            return BadRequest("Invalid date format. Please provide valid startDate and endDate.");
        }

        // Ensure the end date is after the start date
        if (end < start)
        {
            return BadRequest("endDate cannot be before startDate.");
        }

        string url = $"https://www.hebcal.com/hebcal?v=1&cfg=json&maj=on&min=on&mod=on&nx=on&geo=city&city={Uri.EscapeDataString(location)}&start={start:yyyy-MM-dd}&end={end:yyyy-MM-dd}&s=on&M=on";

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