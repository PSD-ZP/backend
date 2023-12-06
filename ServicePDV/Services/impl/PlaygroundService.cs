using PlaygroundHandler.Models;
using PlaygroundWeatherState.DryCalculator;
using ServicePDV.Models.Response;
using ServicePVD.Models.Request;
using ServicePVD.Services;

namespace ServicePDV.Services.impl
{
    public class PlaygroundService : IPlaygroundService
    {
        private readonly IWeatherService _weatherService;
        private readonly IDryingTimeCalculator _dryingTimeCalculator;

        public PlaygroundService(IWeatherService weatherService, IDryingTimeCalculator dryingTimeCalculator) 
        {
            _weatherService = weatherService;
            _dryingTimeCalculator = dryingTimeCalculator;
        }

        public async Task<List<Playground>> GetPlaygrounds(RequestCoordinates coordinates)
        {

            ResponseDryingInfo responseDryingInfo = await _weatherService.GetDryingInfo(coordinates);
            List<Playground> playgrounds = CreateTempPlayground();

            playgrounds = _dryingTimeCalculator.GetPlaygrounds(responseDryingInfo.AvgWetnessInfos, responseDryingInfo.DryingInfos, playgrounds);

            return playgrounds;
        }

        private static List<Playground> CreateTempPlayground()
        {
            Playground smykalka = new Playground
            {
                Name = "Šmýkalka",
                Material = PlaygroundHandler.Enums.Materials.Metal
            };

            Playground hojdacka = new Playground
            {
                Name = "Hojdačka",
                Material = PlaygroundHandler.Enums.Materials.Plastic
            };

            Playground pieskovisko = new Playground
            {
                Name = "Pieskovisko",
                Material = PlaygroundHandler.Enums.Materials.Sand
            };

            Playground hojdaciKonik = new Playground
            {
                Name = "Hojdací koník",
                Material = PlaygroundHandler.Enums.Materials.Wood
            };


            List<Playground> playgrounds = new List<Playground>() { smykalka, hojdacka, pieskovisko, hojdaciKonik };

            return playgrounds;
        }
    }
}
