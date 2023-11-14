namespace ServicePVD.Models
{
    public class Day
    {
        public string maxtemp_c { get; set; } = default!;

        public string mintemp_c { get; set; } = default!;

        public string avgtemp_c { get; set; } = default!;

        public string maxwind_kph { get; set; } = default!;

        public string totalsnow_cm { get; set; } = default!;

        public string avghumidity { get; set; } = default!;

        public string daily_will_it_rain { get; set; } = default!;

        public string daily_chance_of_rain { get; set; } = default!;        

        public string daily_will_it_snow { get; set; } = default!;

        public string daily_chance_of_snow { get; set; } = default!;

        public string totalprecip_mm { get; set; } = default!;

        public Condition condition { get; set; } = default!;

        public string uv { get; set; } = default!;
    }
}
