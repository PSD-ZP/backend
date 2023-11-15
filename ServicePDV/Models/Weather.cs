namespace ServicePVD.Models
{
    public class Weather
    {
        public Location Location { get; set; } = default!;

        public Current Current { get; set; } = default!;

        public Forecast Forecast { get; set; } = default!;
    }
}
