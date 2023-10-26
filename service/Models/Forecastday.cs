namespace service.Models
{
    public class Forecastday
    {
        public required string Date { get; set; }

        public required string date_epoch { get; set; }

        public required Day day { get; set; }

        public required Astro astro { get; set; }

        public required List<Hour> hour { get; set; }
    }
}
