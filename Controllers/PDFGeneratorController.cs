using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("[controller]")]
public class PDFGeneratorController : ControllerBase
{
    private static readonly HttpClient client = new HttpClient();

    [HttpPost]
    public async Task<IActionResult> GeneratePDF()
    {
        var payload = new
        {
            template = new
            {
                id = "1209942",
                data = new
                {
                    Name = "sapir",
                    DueDate = "2024-09-22"
                }
            },
            format = "pdf",
            output = "url",
            name = "Certificate Example"
        };

        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "your_token_here");

        try
        {
            var response = await client.PostAsync("https://us1.pdfgeneratorapi.com/api/v4/documents/generate", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, $"שגיאה: {response.StatusCode} - {errorResponse}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            return Ok(responseBody);
        }
        catch (HttpRequestException e)
        {
            return StatusCode(500, $"שגיאת בקשה: {e.Message}");
        }
    }
}
