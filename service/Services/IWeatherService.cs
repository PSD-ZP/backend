using service.Models;
using service.Models.Request;
using service.Models.Response;

namespace service.Services
{
    public interface IWeatherService
    {
        Task<ResponseCurrentWeather> getLastNHourWeather(RequestCoordinates coordinates);
        Task<Weather> getWeatherFromApiAsync(RequestCoordinates coordinates);
    }
}
