using Newtonsoft.Json;

namespace ServicePVD.Models
{
    public class Forecast
    {
        [JsonProperty("forecastday")]
        public List<Forecastday> Forecastdays { get; set; }
    }
}
