namespace ServicePVD.Models.Response
{
    public class ResponseCurrentWeather
    {
        public string Location { get; set; } = default!;

        public List<ResponseCurrentForecast> Forecasts { get; set; } = default!;
    }
}
