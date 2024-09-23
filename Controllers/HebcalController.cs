
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;

//[ApiController]
//[Route("[controller]")]
//public class HebcalController : ControllerBase
//{
//    private readonly HttpClient _httpClient;

//    public HebcalController(HttpClient httpClient)
//    {
//        _httpClient = httpClient;
//    }

//    [HttpGet]
//    public async Task<IActionResult> Get()
//    {
//        string url = "https://www.hebcal.com/hebcal?v=1&cfg=json&maj=on&min=on&mod=on&nx=on&year=now&month=x&ss=on&mf=on&c=on&geo=geoname&geonameid=3448439&M=on&s=on";

//        try
//        {
//            var response = await _httpClient.GetStringAsync(url);
//            var hebcalData = JsonConvert.DeserializeObject<HebcalResponse>(response);

//            if (hebcalData?.Items == null)
//            {
//                return BadRequest("Failed to parse Hebcal data or Items is null.");
//            }

//            return Ok(hebcalData);
//        }
//        catch (Exception ex)
//        {
//            return StatusCode(500, $"Internal server error: {ex.Message}");
//        }
//    }


//    // בקשה עם תאריך ומקום כפרמטרים
//    [HttpGet("byDateAndLocation")]
//    public async Task<IActionResult> GetByDateAndLocation(string location, string date)
//    {
//        // בדיקה האם הפרמטרים לא ריקים
//        if (string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(date))
//        {
//            return BadRequest("Both location and date parameters are required.");
//        }

//        // חיפוש העיר ברשימה
//        if (!_cities.TryGetValue(location, out int geonameId))
//        {
//            return BadRequest($"City '{location}' not found.");
//        }

//        // התאמת ה-URL לבקשה עם הפרמטרים שהתקבלו
//        string url = $"https://www.hebcal.com/hebcal?v=1&cfg=json&maj=on&min=on&mod=on&nx=on&ss=on&mf=on&c=on&geo=geoname&geonameid={geonameId}&start={date}";

//        try
//        {
//            // שליחת הבקשה ל-API
//            var response = await _httpClient.GetStringAsync(url);
//            var hebcalData = JsonConvert.DeserializeObject<HebcalResponse>(response);

//            if (hebcalData?.Items == null)
//            {
//                return BadRequest("Failed to parse Hebcal data or Items is null.");
//            }

//            // החזרת הנתונים בהצלחה
//            return Ok(hebcalData);
//        }
//        catch (Exception ex)
//        {
//            return StatusCode(500, $"Internal server error: {ex.Message}");
//        }
//    }

//}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class HebcalController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly Dictionary<string, int> _cities = new Dictionary<string, int>
    {
        {"Andorra La Vella", 3041563},
        {"Abu Dhabi", 292968},
        {"Dubai", 292223},
        {"Kabul", 1138958},
        {"The Valley", 3573374},
        {"Tirana", 3183875},
        {"Yerevan", 616052},
        {"Luanda", 2240449},
        {"Buenos Aires", 3435910},
        {"Cordoba", 3860259},
        {"Rosario", 3838583},
        {"Pago Pago", 5881576},
        {"Vienna", 2761369},
        {"Adelaide", 2078025},
        {"Brisbane", 2174003},
        {"Canberra", 2172517},
        {"Gold Coast", 2165087},
        {"Hobart", 2163355},
        {"Melbourne", 2158177},
        {"Perth", 2063523},
        {"Sydney", 2147714},
        {"Oranjestad", 3577154},
        {"Baku", 587084},
        {"Sarajevo", 3191281},
        {"Bridgetown", 3374036},
        {"Chittagong", 1205733},
        {"Dhaka", 1185241},
        {"Khulna", 1336135},
        {"Brussels", 2800866},
        {"Ouagadougou", 2357048},
        {"Sofia", 727011},
        {"Manama", 290340},
        {"Bujumbura", 425378},
        {"Porto-novo", 2392087},
        {"Hamilton", 3573197},
        {"Bandar Seri Begawan", 1820906},
        {"La Paz", 3911925},
        {"Santa Cruz de la Sierra", 3904906},
        {"Belo Horizonte", 3470127},
        {"Brasilia", 3469058},
        {"Fortaleza", 3399415},
        {"Rio de Janeiro", 3451190},
        {"Salvador", 3450554},
        {"Sao Paulo", 3448439},
        {"Nassau", 3571824},
        {"Thimphu", 1252416},
        {"Gaborone", 933773},
        {"Minsk", 625144},
        {"Belmopan", 3582672},
        {"Calgary", 5913490},
        {"Edmonton", 5946768},
        {"Halifax", 6324729},
        {"Mississauga", 6075357},
        {"Montreal", 6077243},
        {"Ottawa", 6094817},
        {"Quebec City", 6325494},
        {"Regina", 6119109},
        {"Saskatoon", 6141256},
        {"St. John's", 6324733},
        {"Toronto", 6167865},
        {"Vancouver", 6173331},
        {"Victoria", 6174041},
        {"Winnipeg", 6183235},
        {"Kinshasa", 2314302},
        {"Lubumbashi", 922704},
        {"Bangui", 2389853},
        {"Brazzaville", 2260535},
        {"Bern", 2661552},
        {"Geneva", 2660646},
        {"Zurich", 2657896},
        {"Abidjan", 2293538},
        {"Yamoussoukro", 2279755},
        {"Avarua", 4035715},
        {"Santiago", 3871336},
        {"Douala", 2232593},
        {"Yaounde", 2220957},
        {"Beijing", 181}
    };

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

        if (!_cities.TryGetValue(location, out int geonameId))
        {
            return BadRequest($"City '{location}' not found.");
        }

        string url = $"https://www.hebcal.com/hebcal?v=1&cfg=json&maj=on&min=on&mod=on&nx=on&ss=on&mf=on&c=on&geo=geoname&geonameid={geonameId}&start={date}";

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
