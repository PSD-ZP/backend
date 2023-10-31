using ServicePVD.Models;
using ServicePVD.Models.Request;
using ServicePVD.Models.Response;

namespace ServicePVD.Services
{
    public interface IWeatherService
    {
        Task<ResponseCurrentWeather> getLastNHourWeather(RequestCoordinates coordinates);
        Task<Weather> getWeatherFromApiAsync(RequestCoordinates coordinates);
    }
}
