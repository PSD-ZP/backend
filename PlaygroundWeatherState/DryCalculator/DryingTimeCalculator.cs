using Microsoft.Extensions.Logging;
using PlaygroundWeatherState.Models;
using PlaygroundWeatherState.WetnessScoreCalculator;

namespace PlaygroundWeatherState.DryCalculator
{
    public class DryingTimeCalculator : IDryingTimeCalculator
    {
        private readonly IWetnessScore _wetnessScore;
        private readonly ILogger<DryingTimeCalculator> _logger;

        public DryingTimeCalculator(IWetnessScore wetnessScore, ILogger<DryingTimeCalculator> logger) 
        {
            _wetnessScore = wetnessScore;
            _logger = logger;
        }

        public int GetHoursOfDrying(List<WetnessInfo> avgWetnessInfos, List<DryingInfo> dryingInfos)
        {
            double wetnessScore = _wetnessScore.GetWetnessScore(avgWetnessInfos);

            int hours = DryingTimeCalculating(1, wetnessScore, dryingInfos);

            return hours;
        }

        private int DryingTimeCalculating(double materialWeight, double initWetnessScore, List<DryingInfo> dryingInfos)
        {
            int dryingHours = 0;
            double currentWetnessScore = initWetnessScore;

            foreach (var dryingInfo in dryingInfos)
            {
                double currentTemp = NormalizeValue(dryingInfo.Temperature, -15, 40);
                double currentPrecip = NormalizeValue(dryingInfo.Precipitation, 0, 50);
                double currentHumidity = NormalizeValue(dryingInfo.Humidity, 30, 90);
                double currentCloudiness = NormalizeValue(dryingInfo.Cloudiness, 0, 100);

                double tempWeight = 0.2;
                double precipWeight = 0.6;
                double humidityWeight = 0.1;
                double cloudinessWeight = 0.1;

                if (dryingInfo.Precipitation > 1)
                {
                    tempWeight = 0.1;
                    precipWeight = 0.7;
                }
                else if (dryingInfo.Temperature > 20 && dryingInfo.Precipitation < 0.2)
                {
                    tempWeight = 0.4;
                    precipWeight = 0.0;
                    cloudinessWeight = 0.2;
                }
                else if (dryingInfo.Temperature < 5 && dryingInfo.Precipitation < 0.2)
                {
                    tempWeight = 0.5;
                    precipWeight = 0.2;
                    cloudinessWeight = 0.2;
                }

                currentWetnessScore += (materialWeight * ((currentHumidity * humidityWeight) + (currentPrecip * precipWeight)))
                    - ((currentTemp * tempWeight) - (currentCloudiness * cloudinessWeight));

                _logger.LogDebug($"Current hour: x  Current wetness score: {currentWetnessScore}");

                if (currentWetnessScore < 0.2)
                {
                    break;
                }
                dryingHours++;
            }

            // Current weather conditions are not good
            if (dryingHours == dryingInfos.Count)
            {
                return -1;
            }

            return dryingHours;

        }

        public static double NormalizeValue(double value, double min, double max)
        {
            return Math.Max(0.0, Math.Min(100.0, (value - min) / (max - min)));
        }
    }
}
