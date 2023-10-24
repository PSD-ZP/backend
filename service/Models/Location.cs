using Newtonsoft.Json;
using service.Convertor;

namespace service.Models
{
    public class Location
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("tz_id")]
        public string TimeZoneId { get; set; }

        [JsonProperty("localtime_epoch")]
        public int LocalTimeEpoch { get; set; }

        [JsonProperty("localtime")]
        public string LocalTime { get; set; }
    }

}
