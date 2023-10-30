using Newtonsoft.Json;

namespace WeatherHandler.Request
{
    public class RequestCoordinates
    {
        [JsonProperty("lat")]
        public string? Latitude { get; set; }

        [JsonProperty("lon")]
        public string? Longitude { get; set; }

        [JsonProperty("location")]
        public string? Location { get; set; }
    }
}
