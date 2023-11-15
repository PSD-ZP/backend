using Newtonsoft.Json;

namespace ServicePVD.Models
{
    public class Hour
    {
        [JsonProperty("time_epoch")]
        public string TimeEpoch { get; set; } = default!;

        public string Time { get; set; } = default!;

        [JsonProperty("temp_c")]
        public string Temperature { get; set; } = default!;

        [JsonProperty("is_day")]
        public string IsDay { get; set; } = default!;

        public Condition Condition { get; set; } = default!;

        [JsonProperty("wind_kph")]
        public string WindKmph { get; set; } = default!;

        [JsonProperty("wind_dir")]
        public string WindDirection { get; set; } = default!;

        [JsonProperty("pressure_in")]
        public string PressureIn { get; set; } = default!;

        public string Humidity { get; set; } = default!;

        public string Cloud { get; set; } = default!;

        [JsonProperty("feelslike_c")]
        public string FeelslikeTemperature { get; set; } = default!;

        [JsonProperty("windchill_c")]
        public string WindchillTemperature { get; set; } = default!;

        [JsonProperty("will_it_rain")]
        public string WillItRain { get; set; } = default!;

        [JsonProperty("precip_mm")]
        public string Precipitation { get; set; } = default!;

        [JsonProperty("chance_of_rain")]
        public string ChanceOfRain { get; set; } = default!;

        [JsonProperty("will_it_snow")]
        public string WillItSnow { get; set; } = default!;

        [JsonProperty("chance_of_snow")]
        public string ChanceOfSnow { get; set; } = default!;

        [JsonProperty("vis_km")]
        public string VisKm { get; set; } = default!;

        public string Uv { get; set; } = default!;
    }
}
