using service.Models;

namespace service.Services.impl
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(ILogger<WeatherService> logger)
        {
            _logger = logger;
        }

        public Weather createWeather()
        {
            Weather weather = new Weather()
            {
                Id = Guid.NewGuid(),
                Temperature = 23.5,
                Day = "Monday"
            };

            _logger.LogDebug("Successfully created new object.");

            return weather;
        }
    }
}
