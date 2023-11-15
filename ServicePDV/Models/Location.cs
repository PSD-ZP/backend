using Newtonsoft.Json;

namespace ServicePVD.Models
{
    public class Location
    {
        public string Name { get; set; } = default!;

        public string Region { get; set; } = default!;

        public string Country { get; set; } = default!;

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("tz_id")]
        public string TimeZoneId { get; set; } = default!;

        [JsonProperty("localtime_epoch")]
        public int LocalTimeEpoch { get; set; } = default!;

        public string LocalTime { get; set; } = default!;
    }

}
