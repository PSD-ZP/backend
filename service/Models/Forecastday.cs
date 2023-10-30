namespace WeatherHandler
{
    public class Forecastday
    {
        public string Date { get; set; }

        public string date_epoch { get; set; }

        public Day day { get; set; }

        public Astro astro { get; set; }

        public List<Hour> hour { get; set; }
    }
}
