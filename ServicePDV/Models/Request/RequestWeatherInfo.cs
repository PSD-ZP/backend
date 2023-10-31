using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ServicePDV.Models.Request
{
    public class RequestWeatherInfo
    {
        [JsonProperty("temp")]
        [JsonRequired]
        public double Temperature { get; set; }

        [JsonProperty("wind")]
        [JsonRequired]
        public double WindKmph { get; set; }

        [JsonProperty("clouds")]
        [JsonRequired]
        public double Clouds { get; set; }

        [JsonProperty("rain")]
        [JsonRequired]
        public double ChanceOfRain { get; set; }

        [JsonProperty("snow")]
        [JsonRequired]
        public double ChanceOfSnow { get; set; }
    }
}
