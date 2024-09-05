using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mcv_project2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImaggaController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        // Constructor to initialize the HttpClient used for making API requests.
        public ImaggaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Endpoint that accepts an image file via HTTP POST, sends it to the Imagga API for analysis, 
        // and returns the resulting tags and confidence levels.
        [HttpPost("analyzeImage")]
        public async Task<IActionResult> AnalyzeImage([FromForm] IFormFile image)
        {
            // Check if the image is provided and not empty
            if (image == null || image.Length == 0)
            {
                return BadRequest("No image provided."); 
            }

            string apiKey = "acc_64fadb58df61b78";  // Imagga API key
            string apiSecret = "f5eb8593ce207781e1a4cdea5f8e933d";  // Imagga API secret

            // Create content to send in the API request, including the image file
            using var content = new MultipartFormDataContent();
            using var imageContent = new StreamContent(image.OpenReadStream());
            imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.ContentType); // Set the content type of the image

            content.Add(imageContent, "image", image.FileName); // Add the image to the form data

            // Prepare the API request message
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.imagga.com/v2/tags");
            var authHeader = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{apiKey}:{apiSecret}"));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", authHeader); // Add basic authentication header
            requestMessage.Content = content; // Attach the content to the request

            try
            {
                // Send the API request and wait for the response
                var response = await _httpClient.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode(); // Throw an exception if the response is not successful

                // Read the response content as a JSON string
                var jsonResponse = await response.Content.ReadAsStringAsync();
                // Deserialize the JSON response into an ImaggaResponse object
                var imaggaResponse = JsonConvert.DeserializeObject<ImaggaResponse>(jsonResponse);

                // Return the deserialized response object as a JSON result
                return Ok(imaggaResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
