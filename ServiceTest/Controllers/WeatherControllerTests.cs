using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using ServicePVD.Controllers;
using ServicePVD.Models.Request;
using ServicePVD.Models.Response;
using ServicePVD.Services;
using System.Net;
using System.Text;

namespace ServiceTest.Controllers
{

    [TestFixture]
    internal class WeatherControllerTests
    {
        private WeatherController weatherController;
        private Mock<IWeatherService> weatherServiceMock;

        private WebApplicationFactory<Program> factory;
        private HttpClient client;

        [SetUp]
        public void StartUp()
        {
            weatherServiceMock = new Mock<IWeatherService>();
            weatherController = new WeatherController(weatherServiceMock.Object);

            factory = new WebApplicationFactory<Program>();
            client = factory.CreateClient();
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            client.Dispose();
            factory.Dispose();
        }

        [Test]
        [Category("UnitTest")]
        public async Task GetWeatherByHours_InvalidInput_OnlyLongitudeNull_ReturnsBadRequest()
        {
            var invalidCoordinates = new RequestCoordinates
            {
                Latitude = "40.7128",
                Longitude = null,
                Location = "New York",
            };

            var result = await weatherController.GetWeatherByHours(invalidCoordinates) as BadRequestResult;

            Assert.IsNotNull(result);
            Assert.That(result!.StatusCode, Is.EqualTo(400));
        }

        [Test]
        [Category("UnitTest")]
        public async Task GetWeatherByHours_InvalidInput_OnlyLatitudeNull_ReturnsBadRequest()
        {
            var invalidCoordinates = new RequestCoordinates
            {
                Latitude = null,
                Longitude = "40.7128",
                Location = "New York",
            };

            var result = await weatherController.GetWeatherByHours(invalidCoordinates) as BadRequestResult;

            Assert.IsNotNull(result);
            Assert.That(result!.StatusCode, Is.EqualTo(400));
        }


        [Test]
        [Category("UnitTest")]
        public async Task GetWeatherByHours_ValidInput_Location_ReturnsOk()
        {
            var validCoordinates = new RequestCoordinates
            {
                Latitude = null,
                Longitude = null,
                Location = "New York",
            };

            var expectedWeatherData = new ResponseCurrentWeather
            {
                Location = "New Your",
                Forecasts = new List<ResponseCurrentForecast>
                {
                    new ResponseCurrentForecast
                    {
                        ChanceOfRain = 10,
                        ChanceOfSnow = 20,
                        Clouds = 10,
                        DateTime = DateTime.Now,
                        Temperature = 10,
                        WindKmph = 10
                    }
                }
            };

            var weatherServiceMock = new Mock<IWeatherService>();
            weatherServiceMock.Setup(service => service.GetLast4HourWeather(validCoordinates))
                        .ReturnsAsync(expectedWeatherData);

            var weatherController = new WeatherController(weatherServiceMock.Object);

            var result = await weatherController.GetWeatherByHours(validCoordinates) as OkObjectResult;
            var responseContent = result!.Value as ResponseCurrentWeather;

            Assert.IsNotNull(result);
            Assert.That(result!.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(responseContent);
        }


        [Test]
        [Category("IntegrationTest")]
        public async Task GetWeatherByHours_ValidInput_ReturnsOk()
        {
            var validCoordinates = new RequestCoordinates
            {
                Latitude = "40.7128",
                Longitude = "-74.0060"
            };

            var json = JsonConvert.SerializeObject(validCoordinates);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/Weather/GetWeatherOfLastHours", content);


            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [Category("IntegrationTest")]
        public async Task GetWetnessScoreInfo_ValidInput_ReturnsOk()
        {
            var validCoordinates = new RequestCoordinates
            {
                Latitude = "40.7128",
                Longitude = "-74.0060"
            };

            var json = JsonConvert.SerializeObject(validCoordinates);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/Weather/GetDryingHours", content);


            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}