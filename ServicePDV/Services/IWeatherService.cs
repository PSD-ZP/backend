using PlaygroundWeatherState.Models;
using ServicePVD.Models;
using ServicePVD.Models.Request;
using ServicePVD.Models.Response;

namespace ServicePVD.Services
{
    public interface IWeatherService
    {
        Task<ResponseCurrentWeather> GetLast4HourWeather(RequestCoordinates coordinates);
        Task<Weather> GetWeatherFromApiAsync(string apiUrl);
        Task<List<WetnessInfo>> GetWetnessDataOf2Days(RequestCoordinates coordinates);
        Task<int> GetDryingHours(RequestCoordinates coordinates);
    }
}
