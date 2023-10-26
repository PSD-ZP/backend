using Newtonsoft.Json;
using service.Models;
using service.Models.Request;
using service.Models.Response;
using System.Globalization;

namespace service.Services.impl
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(ILogger<WeatherService> logger)
        {
            _logger = logger;
        }

        public async Task<ResponseCurrentWeather> getLastNHourWeather(RequestCoordinates coordinates)
        {
            Weather weather = await getWeatherFromApiAsync(coordinates);
            ResponseCurrentWeather currentWeathers = PrepareCurrentWeatherBody(weather);

            return currentWeathers;
        }

        public async Task<Weather> getWeatherFromApiAsync(RequestCoordinates coordinates)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = string.Empty;
                    if (string.IsNullOrEmpty(coordinates.Location))
                    {
                        apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key= 5642319e49764b5988f163536231710&q={coordinates.Latitude},{coordinates.Longitude}&days=2&aqi=no&alerts=no";
                    }
                    else
                    {
                        apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key= 5642319e49764b5988f163536231710&q={coordinates.Location}&days=2&aqi=no&alerts=no";
                    }
                    

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    _logger.LogDebug($"Weather data is retrieved from {apiUrl}");

                    if (response.IsSuccessStatusCode)
                    {
                        _logger.LogDebug($"Return status code: {response.StatusCode}");

                        string content = await response.Content.ReadAsStringAsync();
                        Weather? data = JsonConvert.DeserializeObject<Weather>(content);

                        _logger.LogDebug("Data successfully deserialised to the object.");

                        return data!;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return null;
        }


        private ResponseCurrentWeather PrepareCurrentWeatherBody(Weather weather)
        {
            DateTime.TryParseExact(weather.Location.LocalTime, "yyyy-MM-dd HH:mm", null, DateTimeStyles.None, out DateTime parsedDateTime);
            bool onlyToday = parsedDateTime.Hour > 20 ? false : true;

            List<ResponseCurrentForecast> currentForecasts = new List<ResponseCurrentForecast>();



            if (onlyToday)
            {
                _logger.LogDebug("Response is created only from the last 4 hours of the day.");
                IEnumerable<Hour> hours = weather.Forecast.Forecastdays[0].hour.GetRange(parsedDateTime.Hour, 4);

                foreach (var hour in hours)
                {
                    ResponseCurrentForecast forecast = CreateResponseCurrentForecast(hour);
                    currentForecasts.Add(forecast);
                }
            }
            else
            {
                IEnumerable<Hour> hours = weather.Forecast.Forecastdays[0].hour.Skip(parsedDateTime.Hour);
                int todayNumOfHours = hours.Count();
                int tommorowNumOfHours = 4 - todayNumOfHours;

                _logger.LogDebug($"Response is created from the last {todayNumOfHours} hours of today and the first {tommorowNumOfHours} hours of tomorrow");

                foreach (var hour in hours)
                {
                    ResponseCurrentForecast forecast = CreateResponseCurrentForecast(hour);
                    currentForecasts.Add(forecast);
                }

                hours = weather.Forecast.Forecastdays[1].hour.GetRange(0, tommorowNumOfHours);
                foreach (var hour in hours)
                {
                    ResponseCurrentForecast forecast = CreateResponseCurrentForecast(hour);
                    currentForecasts.Add(forecast);
                }

            }

            ResponseCurrentWeather currentWeather = new ResponseCurrentWeather();
            currentWeather.Location = weather.Location.Name;
            currentWeather.Forecasts = currentForecasts;

            _logger.LogDebug("Successfully created response current weather object.");

            return currentWeather;
        }

        private ResponseCurrentForecast CreateResponseCurrentForecast(Hour hour)
        {
            ResponseCurrentForecast forecast = new ResponseCurrentForecast();
            forecast.DateTime = DateTime.ParseExact(hour.time, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            forecast.Temperature = double.Parse(hour.temp_c);
            forecast.WindKmph = double.Parse(hour.wind_kph);
            forecast.ChanceOfRain = double.Parse(hour.chance_of_rain);
            forecast.ChanceOfSnow = double.Parse(hour.chance_of_snow);

            _logger.LogDebug("Created forecast entity.");

            return forecast;
        }

    }
}
