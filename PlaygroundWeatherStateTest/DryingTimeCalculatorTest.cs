using Microsoft.Extensions.Logging;
using Moq;
using PlaygroundWeatherState.DryCalculator;
using PlaygroundWeatherState.Models;
using PlaygroundWeatherState.WetnessScoreCalculator;

namespace PlaygroundWeatherStateTest
{
    [TestFixture]
    public class DryingTimeCalculatorTest
    {
        [Test]
        public void WetnessScoreForDryAndHotDayTest()
        {
            Mock<IWetnessScore> wetnessScore = new Mock<IWetnessScore>();

            List<DryingInfo> dryingInfos = new List<DryingInfo>();
            List<WetnessInfo> wetnessInfos = new List<WetnessInfo>();

            WetnessInfo wetnessInfo = new WetnessInfo
            {
                Humidity = 70,
                Precipitation = 0
            };


            WetnessInfo wetnessInfo2 = new WetnessInfo
            {
                Humidity = 70,
                Precipitation = 0
            };

            WetnessInfo wetnessInfo3 = new WetnessInfo
            {
                Humidity = 70,
                Precipitation = 0
            };

            wetnessInfos.Add(wetnessInfo);
            wetnessInfos.Add(wetnessInfo2);
            wetnessInfos.Add(wetnessInfo3);

            DryingInfo dryingInfo = new DryingInfo
            {
                Humidity = 70,
                Precipitation = 0,
                Temperature = 30,
                Cloudiness = 10
            };

            DryingInfo dryingInfo2 = new DryingInfo
            {
                Humidity = 69,
                Precipitation = 0,
                Temperature = 31,
                Cloudiness = 10
            };

            DryingInfo dryingInfo3 = new DryingInfo
            {
                Humidity = 68,
                Precipitation = 0,
                Temperature = 29,
                Cloudiness = 10
            };

            DryingInfo dryingInfo4 = new DryingInfo
            {
                Humidity = 69,
                Precipitation = 0,
                Temperature = 28,
                Cloudiness = 10
            };


            dryingInfos.Add(dryingInfo);
            dryingInfos.Add(dryingInfo2);
            dryingInfos.Add(dryingInfo3);
            dryingInfos.Add(dryingInfo4);

            DryingTimeCalculator dryingTimeCalculator = new DryingTimeCalculator(wetnessScore.Object, Mock.Of<ILogger<DryingTimeCalculator>>());
            wetnessScore.Setup(service => service.GetWetnessScore(wetnessInfos)).Returns(0.05);

            int dryingHours = dryingTimeCalculator.GetHoursOfDrying(wetnessInfos, dryingInfos);

            Assert.IsTrue(dryingHours != -1);
        }

        [Test]
        public void HighWetnessScoreButUpcomingHoursAreHighTemperatureAndLowHumidityAndNoRainAndZeroCloudiness()
        {

            Mock<IWetnessScore> wetnessScore = new Mock<IWetnessScore>();

            List<DryingInfo> dryingInfos = new List<DryingInfo>();
            List<WetnessInfo> wetnessInfos = new List<WetnessInfo>();

            WetnessInfo wetnessInfo = new WetnessInfo
            {
                Humidity = 80,
                Precipitation = 16
            };


            WetnessInfo wetnessInfo2 = new WetnessInfo
            {
                Humidity = 80,
                Precipitation = 16
            };

            WetnessInfo wetnessInfo3 = new WetnessInfo
            {
                Humidity = 80,
                Precipitation = 16
            };

            wetnessInfos.Add(wetnessInfo);
            wetnessInfos.Add(wetnessInfo2);
            wetnessInfos.Add(wetnessInfo3);

            DryingInfo dryingInfo = new DryingInfo
            {
                Humidity = 65,
                Precipitation = 0,
                Temperature = 25,
                Cloudiness = 0
            };

            DryingInfo dryingInfo2 = new DryingInfo
            {
                Humidity = 62,
                Precipitation = 0,
                Temperature = 28,
                Cloudiness = 0
            };

            DryingInfo dryingInfo3 = new DryingInfo
            {
                Humidity = 63,
                Precipitation = 0,
                Temperature = 29,
                Cloudiness = 0
            };

            DryingInfo dryingInfo4 = new DryingInfo
            {
                Humidity = 65,
                Precipitation = 0,
                Temperature = 31,
                Cloudiness = 0
            };


            dryingInfos.Add(dryingInfo);
            dryingInfos.Add(dryingInfo2);
            dryingInfos.Add(dryingInfo3);
            dryingInfos.Add(dryingInfo4);

            DryingTimeCalculator dryingTimeCalculator = new DryingTimeCalculator(wetnessScore.Object, Mock.Of<ILogger<DryingTimeCalculator>>());
            wetnessScore.Setup(service => service.GetWetnessScore(wetnessInfos)).Returns(0.795);

            int dryingHours = dryingTimeCalculator.GetHoursOfDrying(wetnessInfos, dryingInfos);

            Assert.IsTrue(dryingHours != -1);
        }

        [Test]
        public void LowWetnessScoreButInUpcomingHoursItIsRaining()
        {
            Mock<IWetnessScore> wetnessScore = new Mock<IWetnessScore>();

            List<DryingInfo> dryingInfos = new List<DryingInfo>();
            List<WetnessInfo> wetnessInfos = new List<WetnessInfo>();

            WetnessInfo wetnessInfo = new WetnessInfo
            {
                Humidity = 80,
                Precipitation = 15
            };


            WetnessInfo wetnessInfo2 = new WetnessInfo
            {
                Humidity = 80,
                Precipitation = 15
            };

            WetnessInfo wetnessInfo3 = new WetnessInfo
            {
                Humidity = 80,
                Precipitation = 15
            };

            wetnessInfos.Add(wetnessInfo);
            wetnessInfos.Add(wetnessInfo2);
            wetnessInfos.Add(wetnessInfo3);

            DryingInfo dryingInfo = new DryingInfo
            {
                Humidity = 80,
                Precipitation = 2,
                Temperature = 22,
                Cloudiness = 40
            };

            DryingInfo dryingInfo2 = new DryingInfo
            {
                Humidity = 79,
                Precipitation = 2,
                Temperature = 21,
                Cloudiness = 30
            };

            DryingInfo dryingInfo3 = new DryingInfo
            {
                Humidity = 81,
                Precipitation = 3,
                Temperature = 23,
                Cloudiness = 40
            };

            DryingInfo dryingInfo4 = new DryingInfo
            {
                Humidity = 83,
                Precipitation = 4,
                Temperature = 22,
                Cloudiness = 45
            };


            dryingInfos.Add(dryingInfo);
            dryingInfos.Add(dryingInfo2);
            dryingInfos.Add(dryingInfo3);
            dryingInfos.Add(dryingInfo4);

            DryingTimeCalculator dryingTimeCalculator = new DryingTimeCalculator(wetnessScore.Object, Mock.Of<ILogger<DryingTimeCalculator>>());
            wetnessScore.Setup(service => service.GetWetnessScore(wetnessInfos)).Returns(0.758);

            int dryingHours = dryingTimeCalculator.GetHoursOfDrying(wetnessInfos, dryingInfos);

            Assert.IsTrue(dryingHours == -1);
        }

        [Test]
        public void mixedWeatherStatsAndLowWetnessScore()
        {
            Mock<IWetnessScore> wetnessScore = new Mock<IWetnessScore>();

            List<DryingInfo> dryingInfos = new List<DryingInfo>();
            List<WetnessInfo> wetnessInfos = new List<WetnessInfo>();

            WetnessInfo wetnessInfo = new WetnessInfo
            {
                Humidity = 75,
                Precipitation = 2
            };


            WetnessInfo wetnessInfo2 = new WetnessInfo
            {
                Humidity = 75,
                Precipitation = 2
            };

            WetnessInfo wetnessInfo3 = new WetnessInfo
            {
                Humidity = 75,
                Precipitation = 2
            };

            wetnessInfos.Add(wetnessInfo);
            wetnessInfos.Add(wetnessInfo2);
            wetnessInfos.Add(wetnessInfo3);

            DryingInfo dryingInfo = new DryingInfo
            {
                Humidity = 80,
                Precipitation = 0,
                Temperature = 15,
                Cloudiness = 0
            };

            DryingInfo dryingInfo2 = new DryingInfo
            {
                Humidity = 79,
                Precipitation = 0,
                Temperature = 14,
                Cloudiness = 50
            };

            DryingInfo dryingInfo3 = new DryingInfo
            {
                Humidity = 81,
                Precipitation = 1,
                Temperature = 14,
                Cloudiness = 60
            };

            DryingInfo dryingInfo4 = new DryingInfo
            {
                Humidity = 83,
                Precipitation = 3,
                Temperature = 14,
                Cloudiness = 70
            };


            dryingInfos.Add(dryingInfo);
            dryingInfos.Add(dryingInfo2);
            dryingInfos.Add(dryingInfo3);
            dryingInfos.Add(dryingInfo4);

            DryingTimeCalculator dryingTimeCalculator = new DryingTimeCalculator(wetnessScore.Object, Mock.Of<ILogger<DryingTimeCalculator>>());
            wetnessScore.Setup(service => service.GetWetnessScore(wetnessInfos)).Returns(0.152);

            int dryingHours = dryingTimeCalculator.GetHoursOfDrying(wetnessInfos, dryingInfos);

            Assert.IsTrue(dryingHours != -1);
        }

        [Test]
        public void winterWeatherLowWetnessScore()
        {
            Mock<IWetnessScore> wetnessScore = new Mock<IWetnessScore>();

            List<DryingInfo> dryingInfos = new List<DryingInfo>();
            List<WetnessInfo> wetnessInfos = new List<WetnessInfo>();

            WetnessInfo wetnessInfo = new WetnessInfo
            {
                Humidity = 50,
                Precipitation = 0
            };


            WetnessInfo wetnessInfo2 = new WetnessInfo
            {
                Humidity = 50,
                Precipitation = 0
            };

            WetnessInfo wetnessInfo3 = new WetnessInfo
            {
                Humidity = 50,
                Precipitation = 0
            };

            wetnessInfos.Add(wetnessInfo);
            wetnessInfos.Add(wetnessInfo2);
            wetnessInfos.Add(wetnessInfo3);

            DryingInfo dryingInfo = new DryingInfo
            {
                Humidity = 50,
                Precipitation = 0,
                Temperature = 0,
                Cloudiness = 20
            };

            DryingInfo dryingInfo2 = new DryingInfo
            {
                Humidity = 52,
                Precipitation = 0,
                Temperature = -3,
                Cloudiness = 30
            };

            DryingInfo dryingInfo3 = new DryingInfo
            {
                Humidity = 49,
                Precipitation = 1,
                Temperature = -2,
                Cloudiness = 60
            };

            DryingInfo dryingInfo4 = new DryingInfo
            {
                Humidity = 45,
                Precipitation = 3,
                Temperature = -3,
                Cloudiness = 70
            };


            dryingInfos.Add(dryingInfo);
            dryingInfos.Add(dryingInfo2);
            dryingInfos.Add(dryingInfo3);
            dryingInfos.Add(dryingInfo4);

            DryingTimeCalculator dryingTimeCalculator = new DryingTimeCalculator(wetnessScore.Object, Mock.Of<ILogger<DryingTimeCalculator>>());
            wetnessScore.Setup(service => service.GetWetnessScore(wetnessInfos)).Returns(0.033);

            int dryingHours = dryingTimeCalculator.GetHoursOfDrying(wetnessInfos, dryingInfos);

            Assert.IsTrue(dryingHours != -1);
        }

        [Test]
        public void winterWeatherHighwWetnessScore()
        {
            Mock<IWetnessScore> wetnessScore = new Mock<IWetnessScore>();

            List<DryingInfo> dryingInfos = new List<DryingInfo>();
            List<WetnessInfo> wetnessInfos = new List<WetnessInfo>();

            WetnessInfo wetnessInfo = new WetnessInfo
            {
                Humidity = 50,
                Precipitation = 15
            };


            WetnessInfo wetnessInfo2 = new WetnessInfo
            {
                Humidity = 50,
                Precipitation = 15
            };

            WetnessInfo wetnessInfo3 = new WetnessInfo
            {
                Humidity = 50,
                Precipitation = 15
            };

            wetnessInfos.Add(wetnessInfo);
            wetnessInfos.Add(wetnessInfo2);
            wetnessInfos.Add(wetnessInfo3);

            DryingInfo dryingInfo = new DryingInfo
            {
                Humidity = 50,
                Precipitation = 0,
                Temperature = 0,
                Cloudiness = 20
            };

            DryingInfo dryingInfo2 = new DryingInfo
            {
                Humidity = 52,
                Precipitation = 0,
                Temperature = -3,
                Cloudiness = 30
            };

            DryingInfo dryingInfo3 = new DryingInfo
            {
                Humidity = 49,
                Precipitation = 1,
                Temperature = -2,
                Cloudiness = 50
            };

            DryingInfo dryingInfo4 = new DryingInfo
            {
                Humidity = 45,
                Precipitation = 2,
                Temperature = -3,
                Cloudiness = 20
            };


            dryingInfos.Add(dryingInfo);
            dryingInfos.Add(dryingInfo2);
            dryingInfos.Add(dryingInfo3);
            dryingInfos.Add(dryingInfo4);

            DryingTimeCalculator dryingTimeCalculator = new DryingTimeCalculator(wetnessScore.Object, Mock.Of<ILogger<DryingTimeCalculator>>());
            wetnessScore.Setup(service => service.GetWetnessScore(wetnessInfos)).Returns(0.708);

            int dryingHours = dryingTimeCalculator.GetHoursOfDrying(wetnessInfos, dryingInfos);

            Assert.IsTrue(dryingHours == -1);
        }
    }


}