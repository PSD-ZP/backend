using Newtonsoft.Json;

namespace ServicePVD.Models
{
    public class Forecastday
    {
        public string Date { get; set; } = default!;

        [JsonProperty("date_epoch")]
        public string DateEpoch { get; set; } = default!;

        public Day Day { get; set; } = default!;

        public Astro Astro { get; set; } = default!;

        public List<Hour> Hour { get; set; } = default!;
    }
}
