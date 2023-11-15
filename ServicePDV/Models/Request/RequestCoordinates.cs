using Newtonsoft.Json;

namespace ServicePVD.Models.Request
{
    public class RequestCoordinates
    {
        [JsonProperty("lat")]
        public string? Latitude { get; set; }

        [JsonProperty("lon")]
        public string? Longitude { get; set; }

        public string? Location { get; set; }
    }
}
