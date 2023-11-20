using Microsoft.AspNetCore.Mvc;
using ServicePDV.Services;
using ServicePVD.Models.Request;
using ServicePVD.Services;
using ServicePVD.Services.impl;

namespace ServicePDV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaygroundController : ControllerBase
    {
        private readonly IPlaygroundService _playgroundService;

        public PlaygroundController(IPlaygroundService playgroundService)
        {
            _playgroundService = playgroundService;
        }

        [HttpGet]
        [Route("GetPlaygroundsByCity")]
        public async Task<IActionResult> GetPlaygroundsByCity(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                return BadRequest();
            }

            var playgrounds = await _playgroundService.GetPlaygrounds(location);

            return Ok(playgrounds);
        }

    }
}
