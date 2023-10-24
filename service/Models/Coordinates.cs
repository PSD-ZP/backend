using Newtonsoft.Json;

namespace service.Models
{

    public class Coordinates
    {
        [JsonProperty("lat")]
        public string lat { get; set; }

        [JsonProperty("lon")]
        public string lon { get; set; }
    }
}
