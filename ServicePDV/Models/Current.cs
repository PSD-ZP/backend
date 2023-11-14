namespace ServicePVD.Models
{
    public class Current
    {
        public string Last_Updated_Epoch { get; set; } = default!;

        public string Last_Updated { get; set; } = default!;

        public string Temp_C { get; set; } = default!;

        public string Is_day { get; set; } = default!;

        public Condition Condition { get; set; } = default!;

        public string Wind_kph { get; set; } = default!;

        public string Wind_dir { get; set; } = default!;

        public string Humidity { get; set; } = default!;

        public string Cloud { get; set; } = default!;

        public string Precip_Mm { get; set; } = default!;

        public string Feelslike_C { get; set; } = default!;

        public string Vis_km { get; set; } = default!;

        public string Uv { get; set; } = default!;

    }
}
