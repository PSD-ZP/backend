using Newtonsoft.Json;

namespace ServicePVD.Models
{
    public class Day
    {
        [JsonProperty("maxtemp_c")]
        public string MaxTemperature { get; set; } = default!;

        [JsonProperty("mintemp_c")]
        public string MinTemperature { get; set; } = default!;

        [JsonProperty("avgtemp_c")]
        public string AvgTemperature { get; set; } = default!;

        [JsonProperty("maxwind_kph")]
        public string MaxWindKmph { get; set; } = default!;

        [JsonProperty("totalsnow_cm")]
        public string TotalSnowCm { get; set; } = default!;

        public string AvgHumidity { get; set; } = default!;

        [JsonProperty("daily_will_it_rain")]
        public string DailyWillItRain { get; set; } = default!;

        [JsonProperty("daily_chance_of_rain")]
        public string DailyChanceOfRain { get; set; } = default!;

        [JsonProperty("daily_will_it_snow")]
        public string DailyWillItSnow { get; set; } = default!;

        [JsonProperty("daily_chance_of_snow")]
        public string DailyChanceOfSnow { get; set; } = default!;

        [JsonProperty("totalprecip_mm")]
        public string TotalPrecipitation { get; set; } = default!;

        public Condition Condition { get; set; } = default!;

        public string Uv { get; set; } = default!;
    }
}
