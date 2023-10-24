
namespace service.Models
{
    public class Current
    {
        public string Last_Updated_Epoch { get; set; }
        public string Last_Updated { get; set; } = default!;
        public string Temp_C { get; set; }
        public string Is_day { get; set; }
        public Condition Condition { get; set; } = default!;
        public string Wind_kph { get; set; }
        public string Wind_dir { get; set; } = default!;
        public string Humidity { get; set; }
        public string Cloud { get; set; }
        public string Feelslike_C { get; set; }
        public string Vis_km { get; set; }
        public string Uv { get; set; }

    }
}
