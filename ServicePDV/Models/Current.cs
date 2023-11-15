using Newtonsoft.Json;

namespace ServicePVD.Models
{
    public class Current
    {
        [JsonProperty("last_updated_epoch")]
        public string LastUpdatedEpoch { get; set; } = default!;

        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; } = default!;

        [JsonProperty("temp_c")]
        public string Temperature { get; set; } = default!;

        [JsonProperty("is_day")]
        public string IsDay { get; set; } = default!;

        public Condition Condition { get; set; } = default!;

        [JsonProperty("wind_kph")]
        public string WindKmph { get; set; } = default!;

        [JsonProperty("wind_dir")]
        public string WindDirection { get; set; } = default!;

        public string Humidity { get; set; } = default!;

        public string Cloud { get; set; } = default!;

        [JsonProperty("precip_mm")]
        public string Precipitation { get; set; } = default!;

        [JsonProperty("feelslike_c")]
        public string FeelslikeTemperature { get; set; } = default!;

        [JsonProperty("vis_km")]
        public string VisKm { get; set; } = default!;

        public string Uv { get; set; } = default!;

    }
}
