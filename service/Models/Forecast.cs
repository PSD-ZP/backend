using Newtonsoft.Json;

namespace service.Models
{
    public class Forecast
    {
        [JsonProperty("forecastday")]
        public required List<Forecastday> Forecastdays { get; set; }
    }
}
