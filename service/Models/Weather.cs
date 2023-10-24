namespace service.Models
{
    public class Weather
    {
        public Guid Id { get; set; }
        public string? Day { get; set; }
        public double Temperature { get; set; }
    }
}
