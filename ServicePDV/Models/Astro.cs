using Newtonsoft.Json;

namespace ServicePVD.Models
{
    public class Astro
    {
        public string Sunrise { get; set; } = default!;

        public string Sunset { get; set; } = default!;

        public string Moonrise { get; set; } = default!;

        public string Moonset { get; set; } = default!;

        [JsonProperty("moon_phase")]
        public string MoonPhase { get; set; } = default!;

        [JsonProperty("is_moon_up")]
        public string IsMoonUp { get; set; }  = default!;

        [JsonProperty("is_sun_up")]
        public string IsSunUp { get; set; } = default!;
    }
}
