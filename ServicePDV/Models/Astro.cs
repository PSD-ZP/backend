namespace ServicePVD.Models
{
    public class Astro
    {
        public string sunrise { get; set; } = default!;

        public string sunset { get; set; } = default!;

        public string moonrise { get; set; } = default!;

        public string moonset { get; set; } = default!;

        public string moon_phase { get; set; } = default!;

        public string is_moon_up { get; set; }  = default!;

        public string is_sun_up { get; set; } = default!;
    }
}
