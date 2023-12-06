using Microsoft.AspNetCore.Mvc;
using ServicePDV.Services;
using ServicePVD.Models.Request;

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

        [HttpPost]
        [Route("GetPlaygrounds")]
        public async Task<IActionResult> GetPlaygroundsByCity([FromBody] RequestCoordinates coordinates)
        {
            if (!CheckCoordinate(coordinates))
                return BadRequest();

            var playgrounds = await _playgroundService.GetPlaygrounds(coordinates);

            return Ok(playgrounds);
        }

        private static bool CheckCoordinate(RequestCoordinates coordinates)
        {
            if ((coordinates.Latitude == null && coordinates.Longitude != null) || (coordinates.Latitude != null && coordinates.Longitude == null))
                return false;

            return ((coordinates.Latitude != null && coordinates.Longitude != null) || coordinates.Location != null);
        }

    }
}
