
using Newtonsoft.Json;
using service.Convertor;
using service.Models;
using System.Text.Json.Serialization;

namespace service.Services.impl
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(ILogger<WeatherService> logger)
        {
            _logger = logger;
        }

        public async Task<Weather> getWeatherFromApiAsync(Coordinates coordinates)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key=%205642319e49764b5988f163536231710&q={coordinates.lat},{coordinates.lon}&days=1aqi=no&alerts=no";

                    // Make the GET request and await the response
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Check if the request was successful (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string content = await response.Content.ReadAsStringAsync();

                        Weather data = JsonConvert.DeserializeObject<Weather>(content);
                        Console.WriteLine("Response Content:");

                        return data;
                    }
                    else
                    {
                        Console.WriteLine($"HTTP Request failed with status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return null;
        }

    }
}
