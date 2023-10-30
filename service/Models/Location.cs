using Newtonsoft.Json;

namespace WeatherHandler
{
    public class Location
    {

        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        [JsonProperty("region")]
        public string Region { get; set; } = default!;

        [JsonProperty("country")]
        public string Country { get; set; } = default!;

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("tz_id")]
        public string TimeZoneId { get; set; } = default!;

        [JsonProperty("localtime_epoch")]
        public int LocalTimeEpoch { get; set; } = default!;

        [JsonProperty("localtime")]
        public string LocalTime { get; set; } = default!;
    }

}
