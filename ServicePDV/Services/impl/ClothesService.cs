using ClothesHandler.Calculator;
using ClothesHandler.Models;
using ServicePDV.Models.Request;

namespace ServicePVD.Services.impl
{
    public class ClothesService : IClothesService
    {
        private readonly ILogger<ClothesService> _logger;
        private readonly IRecommendationCalculator _recommendationCalculator;

        public ClothesService(IRecommendationCalculator recommendationCalculator, ILogger<ClothesService> logger) 
        {
            _recommendationCalculator = recommendationCalculator;
            _logger = logger;
        }

        public BodyPart GetClothes(RequestWeatherInfo requestWeatherInfo)
        {

            BodyPart bodyPart = _recommendationCalculator.GetClothes(requestWeatherInfo.Temperature, requestWeatherInfo.WindKmph, requestWeatherInfo.ChanceOfRain,
                requestWeatherInfo.Clouds, requestWeatherInfo.ChanceOfSnow);

            _logger.LogDebug("Successfully get clothes from current weather info.");
            
            return bodyPart;
        }
    }
}
