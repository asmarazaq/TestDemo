using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("api/[controller]")]
public class RealEstateController : ControllerBase
{
    private readonly HttpClient _client;
    private readonly string _apiKey;

    public RealEstateController(IConfiguration configuration)
    {
        _apiKey = configuration.GetSection("Key:RealEstateAPIKey").Value;
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiKey);
        _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "us-real-estate.p.rapidapi.com");
    }


    [HttpGet("rent")]
    public async Task<ActionResult> GetRealEstateForRent(string city, string state)
    {
        var requestUri = $"https://us-real-estate.p.rapidapi.com/v2/for-rent?city={city}&state_code={state}&location=48278&limit=10&offset=0&sort=lowest_price&price_min=1000&price_max=3000&beds_min=1&beds_max=5&baths_min=1&baths_max=5&property_type=apartment&expand_search_radius=25&include_nearby_areas_slug_id=Union-City_NJ%2CHoward-Beach_NY&home_size_min=500&home_size_max=3000&in_unit_features=central_air&community_ammenities=garage_1_or_more&cats_ok=true&dogs_ok=true";

        using (var response = await _client.GetAsync(requestUri))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);

            return Content(body, "application/json"); // Return the response as JSON
        }
    }

    [HttpGet("rent-by-zipcode")]
    public async Task<ActionResult> GetRealEstateForRentByZipCode(string zipcode, int limit = 10, int offset = 1, string sort = "lowest_price")
    {
        var requestUri = $"https://us-real-estate.p.rapidapi.com/v2/for-rent-by-zipcode?zipcode={zipcode}&limit={limit}&offset={offset}&sort={sort}";

        using (var response = await _client.GetAsync(requestUri))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);

            return Content(body, "application/json"); // Return the response as JSON
        }
    }
}
