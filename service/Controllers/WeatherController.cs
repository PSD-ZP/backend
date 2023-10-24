using Microsoft.AspNetCore.Mvc;
using service.Models;
using service.Services;
using service.Services.impl;

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

        [HttpGet]
        public async Task<ActionResult<Weather>> GetWeather()
        {

            var weather = _weatherService.createWeather();
            if(weather == null)
            {
                return NotFound();
            }


            return Ok(weather);
        }


        [HttpPut]
        public async Task<ActionResult<string>> Update(string? date)
        {
            if(date != "Monday")
            {
                return BadRequest($"Invalid day {date}");
            }

            return Ok(date);
        }
    }
}