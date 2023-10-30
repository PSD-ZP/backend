namespace WeatherHandler
{
    public class Day
    {
        public string maxtemp_c { get; set; }

        public string mintemp_c { get; set; }

        public string avgtemp_c { get; set; }

        public string maxwind_kph { get; set; }

        public string totalsnow_cm { get; set; }

        public string avghumidity { get; set; }

        public string daily_will_it_rain { get; set; }

        public string daily_chance_of_rain { get; set; }

        public string daily_will_it_snow { get; set; }

        public string daily_chance_of_snow { get; set; }

        public Condition condition { get; set; }

        public string uv { get; set; }
    }
}
