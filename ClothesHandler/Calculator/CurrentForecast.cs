
namespace ClothesHandler.Calculator
{
    internal class CurrentForecast
    {
        public CurrentForecast(double temperature, double windKmph, double chanceOfRain, double clouds, double chanceOfSnow)
        {
            Temperature = temperature;
            WindKmph = windKmph;
            ChanceOfRain = chanceOfRain;
            Clouds = clouds;
            ChanceOfSnow = chanceOfSnow;
        }

        public double Temperature { get; }

        public double WindKmph { get; }

        public double ChanceOfRain { get; }

        public double Clouds { get; }

        public double ChanceOfSnow { get; }
    }
}
