using service.Models;

namespace service.Services
{
    public interface IWeatherService
    { 
       Task<Weather> getWeatherFromApiAsync(Coordinates coordinates);
    }
}
