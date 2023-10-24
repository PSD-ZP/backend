using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using service.Models;

namespace service.Convertor
{
    public class CustomCoordinatesConverter : JsonConverter<Coordinates>
    {
        public override Coordinates ReadJson(JsonReader reader, Type objectType, Coordinates existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            return new Coordinates
            {
                lat = (string)obj["lat"],
                lon = (string)obj["lon"]
            };
        }

        public override void WriteJson(JsonWriter writer, Coordinates value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
