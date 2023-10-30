using Microsoft.AspNetCore.Mvc;
using service.Services;
using WeatherHandler.Request;

namespace service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {

        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpPost]
        [Route("GetWeatherOfLastHours")]
        public async Task<IActionResult> GetWeatherByHours([FromBody] RequestCoordinates coordinates)
        {
            if (!CheckCoordinate(coordinates))
            {
                return BadRequest();
            }

            var weather = await _weatherService.getLastNHourWeather(coordinates);

            if (weather == null)
            {
                return NotFound();
            }

            return Ok(weather);
        }


        private static bool CheckCoordinate(RequestCoordinates coordinates)
        {
            if ((coordinates.Latitude == null && coordinates.Longitude != null) || (coordinates.Latitude != null && coordinates.Longitude == null))
                return false;

            return ((coordinates.Latitude != null && coordinates.Longitude != null) || coordinates.Location != null);
        }
    }
}