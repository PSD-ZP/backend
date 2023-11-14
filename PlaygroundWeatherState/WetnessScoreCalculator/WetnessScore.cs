using PlaygroundWeatherState.Models;

namespace PlaygroundWeatherState.WetnessScoreCalculator
{
    public class WetnessScore : IWetnessScore
    {
        public WetnessScore()
        {
        }


        public double GetWetnessScore(List<WetnessInfo> avgWetnessInfos)
        {

            WetnessInfo avgWetnessInfo = CalculateAvgHumidityAndPrecipitaition(avgWetnessInfos);

            double humidity = NormalizeValue(avgWetnessInfo.Humidity, 50, 90);
            double precipitation = NormalizeValue(avgWetnessInfo.Precipitation, 0, 50);

            double wetnessScore = CalculateWetnessScore(humidity, precipitation);

            return wetnessScore;
        }

        private static double CalculateWetnessScore(double humidity, double precipitation)
        {
            double humidityWeight = 0.1;
            double precipitationWeight = 0.9;

            double wetnessScore = humidity * humidityWeight + precipitation * precipitationWeight * 2.5;

            return wetnessScore;
        }


        private static double NormalizeValue(double value, double min, double max)
        {
            return Math.Max(0.0, Math.Min(100.0, (value - min) / (max - min)));
        }

        private static WetnessInfo CalculateAvgHumidityAndPrecipitaition(List<WetnessInfo> wetnessDatas)
        {
            double avgTemperature = 0;
            double avgPrecipitation = 0;
            double avgHumidity = 0;

            if (wetnessDatas[0].Precipitation < wetnessDatas[1].Precipitation)
            {
                wetnessDatas.ForEach(x => avgTemperature += x.Temperature);
                avgTemperature /= wetnessDatas.Count;

                switch (avgTemperature)
                {
                    case < 15:
                        wetnessDatas.ForEach(x =>
                        {
                            avgHumidity += x.Humidity;
                            avgPrecipitation += x.Precipitation;
                        });
                        break;

                    case > 23:
                        avgPrecipitation += wetnessDatas[0].Precipitation * 0.7;
                        avgPrecipitation += wetnessDatas[1].Precipitation * 0.3;

                        avgHumidity += wetnessDatas[0].Humidity * 0.7;
                        avgHumidity += wetnessDatas[1].Humidity * 0.3;
                        break;

                    default:
                        avgPrecipitation += wetnessDatas[0].Precipitation * 0.6;
                        avgPrecipitation += wetnessDatas[1].Precipitation * 0.4;

                        avgHumidity += wetnessDatas[0].Humidity * 0.6;
                        avgHumidity += wetnessDatas[1].Humidity * 0.4;
                        break;
                }

                avgHumidity /= wetnessDatas.Count;
                avgPrecipitation /= wetnessDatas.Count;
            }
            else
            {
                avgTemperature = wetnessDatas[0].Temperature;
                avgHumidity = wetnessDatas[0].Humidity;
                avgPrecipitation = wetnessDatas[0].Humidity;
            }

            WetnessInfo responseWetnessData = new WetnessInfo();
            responseWetnessData.Precipitation = avgPrecipitation;
            responseWetnessData.Humidity = avgHumidity;
            responseWetnessData.Temperature = avgTemperature;

            return responseWetnessData;
        }
    }
}
