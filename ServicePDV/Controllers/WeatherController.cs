using Microsoft.AspNetCore.Mvc;
using ServicePVD.Models.Request;
using ServicePVD.Services;

namespace ServicePVD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpPost]
        [Route("GetWeatherOfLastHours")]
        public async Task<IActionResult> GetWeatherByHours([FromBody] RequestCoordinates coordinates)
        {
            if (!CheckCoordinate(coordinates))
                return BadRequest();

            int hours = 5;
            var weather = await _weatherService.GetWeatherByHours(coordinates, hours);

            if (weather == null)
                return NotFound();

            return Ok(weather);
        }

        [HttpPost]
        [Route("GetDryingHours")]
        public async Task<IActionResult> GetDryingHours([FromBody] RequestCoordinates coordinates)
        {
            if (!CheckCoordinate(coordinates))
                return BadRequest();

            var weather = await _weatherService.GetDryingHours(coordinates);

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