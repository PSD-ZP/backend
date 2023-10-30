using WeatherHandler;
using WeatherHandler.Request;
using WeatherHandler.Response;

namespace service.Services
{
    public interface IWeatherService
    {
        Task<ResponseCurrentWeather> getLastNHourWeather(RequestCoordinates coordinates);
        Task<Weather> getWeatherFromApiAsync(RequestCoordinates coordinates);
    }
}
