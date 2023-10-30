using Newtonsoft.Json;

namespace WeatherHandler
{
    public class Forecast
    {
        [JsonProperty("forecastday")]
        public List<Forecastday> Forecastdays { get; set; }
    }
}
