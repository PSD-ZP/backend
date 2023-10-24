using Microsoft.AspNetCore.Mvc;
using service.Models;
using service.Services;

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
        [Route("GetWeatherByCoordinates")]
        public async Task<ActionResult<Weather>> GetWeather([FromBody] Coordinates coordinates)
        {

            var weather = await _weatherService.getWeatherFromApiAsync(coordinates);

            return new JsonResult(weather);
        }


        [HttpPost]
        public async Task<ActionResult<string>> Update([FromBody] string date)
        {
            if(date != "Monday")
            {
                return BadRequest($"Invalid day {date}");
            }

            return Ok(date);
        }
    }
}