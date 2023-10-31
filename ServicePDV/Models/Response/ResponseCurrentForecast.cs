namespace ServicePVD.Models.Response
{
    public class ResponseCurrentForecast
    {
        public DateTime DateTime { get; set; } = default!;

        public double Temperature { get; set; }

        public double WindKmph { get; set; }

        public double ChanceOfRain { get; set; }

        public double Clouds { get; set; }

        public double ChanceOfSnow { get; set; }
    }
}
