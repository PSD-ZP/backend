namespace service.Models
{
    public class Hour
    {
        public string time_epoch { get; set; }
        public string time { get; set; }
        public string temp_c { get; set; }
        public string is_day { get; set; }
        public Condition condition { get; set; }
        public string wind_kph { get; set; }
        public string wind_dir { get; set; }
        public string pressure_in { get; set; }
        public string humidity { get; set; }
        public string cloud { get; set; }
        public string feelslike_c { get; set; }
        public string windchill_c { get; set; }
        public string will_it_rain { get; set; }
        public string chance_of_rain { get; set; }
        public string will_it_snow { get; set; }
        public string chance_of_snow { get; set; }
        public string vis_km { get; set; }
        public string uv { get; set; }
    }
}
