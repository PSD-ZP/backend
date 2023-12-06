using ServicePDV.Models.Response;
using ServicePVD.Models;
using ServicePVD.Models.Request;
using ServicePVD.Models.Response;

namespace ServicePVD.Services
{
    public interface IWeatherService
    {
        Task<Weather> GetWeatherFromApiAsync(string apiUrl);
        Task<ResponseCurrentWeather> GetWeatherByHours(RequestCoordinates coordinates, int hours);
        Task<ResponseDryingInfo> GetDryingInfo(RequestCoordinates coordinates);
    }
}
