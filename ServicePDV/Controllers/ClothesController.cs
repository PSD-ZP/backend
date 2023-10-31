using ClothesHandler.Models;
using Microsoft.AspNetCore.Mvc;
using ServicePDV.Models.Request;
using ServicePVD.Services;

namespace ServicePDV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClothesController : ControllerBase
    {
        private readonly IClothesService _clothesService;

        public ClothesController(IClothesService clothesService)
        {
            _clothesService = clothesService;
        }

        [HttpPost]
        [Route("GetClothes")]
        public IActionResult GetClothes([FromBody] RequestWeatherInfo requestWeatherInfo)
        {
            BodyPart bodyPart = _clothesService.GetClothes(requestWeatherInfo);

            return Ok(bodyPart);
        }
    }
}
