using Newtonsoft.Json;
using PlaygroundWeatherState.DryCalculator;
using PlaygroundWeatherState.Models;
using ServicePDV.Utils;
using ServicePDV.Utils.Mappers;
using ServicePVD.Models;
using ServicePVD.Models.Request;
using ServicePVD.Models.Response;
using System.Globalization;

namespace ServicePVD.Services.impl
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;
        private readonly IDryingTimeCalculator _dryingTimeCalculator;

        public WeatherService(IDryingTimeCalculator dryingTimeCalculator, ILogger<WeatherService> logger)
        {
            _dryingTimeCalculator = dryingTimeCalculator;
            _logger = logger;
        }

        public async Task<int> GetDryingHours(RequestCoordinates coordinates)
        {
            List<WetnessInfo> avgWetnessInfos = await GetWetnessDataOf2Days(coordinates);
            ResponseCurrentWeather currentWeather = await GetLast4HourWeather(coordinates);
            List<DryingInfo> dryingInfos = PrepareDryingInfo(currentWeather);

            int hours = _dryingTimeCalculator.GetHoursOfDrying(avgWetnessInfos, dryingInfos);
            return hours;
        }

        private List<DryingInfo> PrepareDryingInfo(ResponseCurrentWeather currentWeather)
        {
            List<DryingInfo> dryingInfos = new List<DryingInfo>();

            foreach (var hour in currentWeather.Forecasts)
            {
                DryingInfo dryingInfo = new DryingInfo
                {
                    Cloudiness = hour.Clouds,
                    Humidity = hour.Humidity,
                    Precipitation = hour.Precipitation,
                    Temperature = hour.Temperature
                };

                dryingInfos.Add(dryingInfo);
            }

            return dryingInfos;
        }

        public async Task<List<WetnessInfo>> GetWetnessDataOf2Days(RequestCoordinates coordinates)
        {
            DateTime currentDate = DateTime.Now;
            DateTime yesterday = currentDate.AddDays(-1);

            List<string> days = new List<string>() { currentDate.ToString("yyyy-MM-dd"), yesterday.ToString("yyyy-MM-dd") };
            List<WetnessInfo> wetnessDatas = new List<WetnessInfo>();

            string apiUrl;
            if (string.IsNullOrEmpty(coordinates.Location))
            {
                apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key= 5642319e49764b5988f163536231710&q={coordinates.Latitude},{coordinates.Longitude}";
            }
            else
            {
                apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key= 5642319e49764b5988f163536231710&q={coordinates.Location}";
            }

            foreach (string day in days)
            {
                string dateApiUrl = $"{apiUrl}&dt={day}";
                Weather weather = await GetWeatherFromApiAsync(dateApiUrl);

                WetnessInfo responseWetnessData = new WetnessInfo();
                responseWetnessData.Precipitation = double.Parse(weather.Forecast.Forecastdays[0].Day.TotalPrecipitation);
                responseWetnessData.Humidity = double.Parse(weather.Forecast.Forecastdays[0].Day.AvgHumidity);
                responseWetnessData.Temperature = double.Parse(weather.Forecast.Forecastdays[0].Day.AvgTemperature);

                wetnessDatas.Add(responseWetnessData);
            }

            return wetnessDatas;
        }

        public async Task<ResponseCurrentWeather> GetLast4HourWeather(RequestCoordinates coordinates)
        {
            Weather weather = await GetLast4HoursUnpreparedWeather(coordinates);
            ResponseCurrentWeather currentWeathers = PrepareCurrentWeatherBody(weather);

            return currentWeathers;
        }

        public async Task<Weather> GetWeatherFromApiAsync(string apiUrl)
        {
            using HttpClient client = new HttpClient();
            try
            {
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
                else
                {
                    throw new HttpRequestException($"Get invalid status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }


        private async Task<Weather> GetLast4HoursUnpreparedWeather(RequestCoordinates coordinates)
        {
            string apiUrl;
            if (string.IsNullOrEmpty(coordinates.Location))
            {
                apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key= 5642319e49764b5988f163536231710&q={coordinates.Latitude},{coordinates.Longitude}&days=2&aqi=no&alerts=no";
            }
            else
            {
                apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key= 5642319e49764b5988f163536231710&q={coordinates.Location}&days=2&aqi=no&alerts=no";
            }

            Weather weather = await GetWeatherFromApiAsync(apiUrl);

            return weather;
        }

        private ResponseCurrentWeather PrepareCurrentWeatherBody(Weather weather)
        {
            DateTime.TryParseExact(weather.Location.LocalTime, "yyyy-MM-dd HH:mm", null, DateTimeStyles.None, out DateTime parsedDateTime);
            bool onlyToday = parsedDateTime.Hour > 20 ? false : true;

            List<ResponseCurrentForecast> currentForecasts = new List<ResponseCurrentForecast>();

            if (onlyToday)
            {
                _logger.LogDebug("Response is created only from the last 4 hours of the day.");
                IEnumerable<Hour> hours = weather.Forecast.Forecastdays[0].Hour.GetRange(parsedDateTime.Hour, 4);

                foreach (var hour in hours)
                {
                    ResponseCurrentForecast forecast = CreateResponseCurrentForecast(hour);
                    currentForecasts.Add(forecast);
                }
            }
            else
            {
                IEnumerable<Hour> hours = weather.Forecast.Forecastdays[0].Hour.Skip(parsedDateTime.Hour);
                int todayNumOfHours = hours.Count();
                int tommorowNumOfHours = 4 - todayNumOfHours;

                _logger.LogDebug($"Response is created from the last {todayNumOfHours} hours of today and the first {tommorowNumOfHours} hours of tomorrow");

                foreach (var hour in hours)
                {
                    ResponseCurrentForecast forecast = CreateResponseCurrentForecast(hour);
                    currentForecasts.Add(forecast);
                }

                hours = weather.Forecast.Forecastdays[1].Hour.GetRange(0, tommorowNumOfHours);
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
            forecast.DateTime = DateTime.ParseExact(hour.Time, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            forecast.Temperature = double.Parse(hour.Temperature);
            forecast.WindKmph = double.Parse(hour.WindKmph);
            forecast.Clouds = double.Parse(hour.Cloud);
            forecast.ChanceOfRain = double.Parse(hour.ChanceOfRain);
            forecast.ChanceOfSnow = double.Parse(hour.ChanceOfSnow);
            forecast.Precipitation = double.Parse(hour.Precipitation);
            forecast.Humidity = double.Parse(hour.Humidity);
            forecast.ConditionDestription =  WeatherStateMapper.translateEnglishWeatherStateToSlovak(hour.Condition.Text);
            forecast.IconUrl = UtilFunctions.changePngDimensionsInUrl(hour.Condition.Icon, 256);

            _logger.LogDebug("Created forecast entity.");

            return forecast;
        }

    }
}
