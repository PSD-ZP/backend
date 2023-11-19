namespace ServicePVD.Models.Response
{
    public class ResponseCurrentForecast
    {
        public DateTime DateTime { get; set; } = default!;

        public string DayOfTheWeek { get; set; } = default!;

        public string ConditionDestription { get; set; } = default!;

        public string IconUrl { get; set; } = default!;

        public double Temperature { get; set; }

        public double WindKmph { get; set; }

        public double Clouds { get; set; }

        public double Humidity { get; set; }

        public double Precipitation { get; set; }

        public double ChanceOfRain { get; set; }

        public double ChanceOfSnow { get; set; }
    }
}
