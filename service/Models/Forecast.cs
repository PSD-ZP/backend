﻿using Newtonsoft.Json;

namespace service.Models
{
    public class Forecast
    {
        [JsonProperty("forecastday")]
        public List<Forecastday> forecastdays { get; set; }
    }
}
