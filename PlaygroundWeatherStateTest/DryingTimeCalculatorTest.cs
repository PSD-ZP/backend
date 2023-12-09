using Microsoft.Extensions.Logging;
using Moq;
using PlaygroundHandler.Models;
using PlaygroundWeatherState.DryCalculator;
using PlaygroundWeatherState.Models;
using PlaygroundWeatherState.WetnessScoreCalculator;

namespace PlaygroundWeatherStateTest
{
    [TestFixture]
    public class DryingTimeCalculatorTest
    {
        [Test]
        [Category("UnitTest")]
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


            WetnessInfo wetnessInfoToday = new WetnessInfo
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
            wetnessInfos.Add(wetnessInfoToday);
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

            List<Playground> playgrounds = new List<Playground>();

            Playground playground1 = new Playground
            {
                Name = "Ocelova smykalka",
                Material = PlaygroundHandler.Enums.Materials.Metal,
                Description = "foo",
                DryTime = 0
            };

            Playground playground2 = new Playground
            {
                Name = "Pieskovisko",
                Material = PlaygroundHandler.Enums.Materials.Sand,
                Description = "foo",
                DryTime = 0
            };

            Playground playground3 = new Playground
            {
                Name = "Hojdaci konik",
                Material = PlaygroundHandler.Enums.Materials.Metal,
                Description = "foo",
                DryTime = 0
            };

            Playground playground4 = new Playground
            {
                Name = "Preliezacka",
                Material = PlaygroundHandler.Enums.Materials.Plastic,
                Description = "foo",
                DryTime = 0
            };

            playgrounds.Add(playground1);
            playgrounds.Add(playground2);
            playgrounds.Add(playground3);
            playgrounds.Add(playground4);

            DryingTimeCalculator dryingTimeCalculator = new DryingTimeCalculator(wetnessScore.Object, Mock.Of<ILogger<DryingTimeCalculator>>());
            wetnessScore.Setup(service => service.GetWetnessScore(wetnessInfos)).Returns(0.05);

            playgrounds = dryingTimeCalculator.GetPlaygrounds(wetnessInfos, dryingInfos, playgrounds);

            foreach (Playground playground in playgrounds)
            {
                Assert.IsTrue(playground.DryTime != -1);
            }

        }

        [Test]
        [Category("UnitTest")]
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


            WetnessInfo wetnessInfoToday = new WetnessInfo
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
            wetnessInfos.Add(wetnessInfoToday);
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


            List<Playground> playgrounds = new List<Playground>();

            Playground playground1 = new Playground
            {
                Name = "Ocelova smykalka",
                Material = PlaygroundHandler.Enums.Materials.Metal,
                Description = "foo",
                DryTime = 0
            };

            Playground playground2 = new Playground
            {
                Name = "Pieskovisko",
                Material = PlaygroundHandler.Enums.Materials.Sand,
                Description = "foo",
                DryTime = 0
            };

            Playground playground3 = new Playground
            {
                Name = "Hojdaci konik",
                Material = PlaygroundHandler.Enums.Materials.Metal,
                Description = "foo",
                DryTime = 0
            };

            Playground playground4 = new Playground
            {
                Name = "Preliezacka",
                Material = PlaygroundHandler.Enums.Materials.Plastic,
                Description = "foo",
                DryTime = 0
            };

            playgrounds.Add(playground1);
            playgrounds.Add(playground2);
            playgrounds.Add(playground3);
            playgrounds.Add(playground4);

            DryingTimeCalculator dryingTimeCalculator = new DryingTimeCalculator(wetnessScore.Object, Mock.Of<ILogger<DryingTimeCalculator>>());
            wetnessScore.Setup(service => service.GetWetnessScore(wetnessInfos)).Returns(0.795);

            playgrounds = dryingTimeCalculator.GetPlaygrounds(wetnessInfos, dryingInfos, playgrounds);

            foreach (Playground playground in playgrounds)
            {
                Assert.IsTrue(playground.DryTime == -1);
            }
        }

        [Test]
        [Category("UnitTest")]
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


            WetnessInfo wetnessInfoToday = new WetnessInfo
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
            wetnessInfos.Add(wetnessInfoToday);
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

            List<Playground> playgrounds = new List<Playground>();

            Playground playground1 = new Playground
            {
                Name = "Ocelova smykalka",
                Material = PlaygroundHandler.Enums.Materials.Metal,
                Description = "foo",
                DryTime = 0
            };

            Playground playground2 = new Playground
            {
                Name = "Pieskovisko",
                Material = PlaygroundHandler.Enums.Materials.Sand,
                Description = "foo",
                DryTime = 0
            };

            Playground playground3 = new Playground
            {
                Name = "Hojdaci konik",
                Material = PlaygroundHandler.Enums.Materials.Metal,
                Description = "foo",
                DryTime = 0
            };

            Playground playground4 = new Playground
            {
                Name = "Preliezacka",
                Material = PlaygroundHandler.Enums.Materials.Plastic,
                Description = "foo",
                DryTime = 0
            };

            playgrounds.Add(playground1);
            playgrounds.Add(playground2);
            playgrounds.Add(playground3);
            playgrounds.Add(playground4);

            DryingTimeCalculator dryingTimeCalculator = new DryingTimeCalculator(wetnessScore.Object, Mock.Of<ILogger<DryingTimeCalculator>>());
            wetnessScore.Setup(service => service.GetWetnessScore(wetnessInfos)).Returns(0.05);

            playgrounds = dryingTimeCalculator.GetPlaygrounds(wetnessInfos, dryingInfos, playgrounds);

            foreach (Playground playground in playgrounds)
            {
                Console.WriteLine(playground.Name);
                Assert.IsTrue(playground.DryTime != -1);
            }
        }

        [Test]
        [Category("UnitTest")]
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


            WetnessInfo wetnessInfoToday = new WetnessInfo
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
            wetnessInfos.Add(wetnessInfoToday);
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

            List<Playground> playgrounds = new List<Playground>();

            Playground playground1 = new Playground
            {
                Name = "Ocelova smykalka",
                Material = PlaygroundHandler.Enums.Materials.Metal,
                Description = "foo",
                DryTime = 0
            };

            Playground playground2 = new Playground
            {
                Name = "Pieskovisko",
                Material = PlaygroundHandler.Enums.Materials.Sand,
                Description = "foo",
                DryTime = 0
            };

            Playground playground3 = new Playground
            {
                Name = "Hojdaci konik",
                Material = PlaygroundHandler.Enums.Materials.Metal,
                Description = "foo",
                DryTime = 0
            };

            Playground playground4 = new Playground
            {
                Name = "Preliezacka",
                Material = PlaygroundHandler.Enums.Materials.Plastic,
                Description = "foo",
                DryTime = 0
            };

            playgrounds.Add(playground1);
            playgrounds.Add(playground2);
            playgrounds.Add(playground3);
            playgrounds.Add(playground4);

            DryingTimeCalculator dryingTimeCalculator = new DryingTimeCalculator(wetnessScore.Object, Mock.Of<ILogger<DryingTimeCalculator>>());
            wetnessScore.Setup(service => service.GetWetnessScore(wetnessInfos)).Returns(0.152);

            playgrounds = dryingTimeCalculator.GetPlaygrounds(wetnessInfos, dryingInfos, playgrounds);

            foreach (Playground playground in playgrounds)
            {
                Assert.IsTrue(playground.DryTime != -1);
            }
        }

        [Test]
        [Category("UnitTest")]
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


            WetnessInfo wetnessInfoToday = new WetnessInfo
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
            wetnessInfos.Add(wetnessInfoToday);
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

            List<Playground> playgrounds = new List<Playground>();

            Playground playground1 = new Playground
            {
                Name = "Ocelova smykalka",
                Material = PlaygroundHandler.Enums.Materials.Metal,
                Description = "foo",
                DryTime = 0
            };

            Playground playground2 = new Playground
            {
                Name = "Pieskovisko",
                Material = PlaygroundHandler.Enums.Materials.Sand,
                Description = "foo",
                DryTime = 0
            };

            Playground playground3 = new Playground
            {
                Name = "Hojdaci konik",
                Material = PlaygroundHandler.Enums.Materials.Metal,
                Description = "foo",
                DryTime = 0
            };

            Playground playground4 = new Playground
            {
                Name = "Preliezacka",
                Material = PlaygroundHandler.Enums.Materials.Plastic,
                Description = "foo",
                DryTime = 0
            };

            playgrounds.Add(playground1);
            playgrounds.Add(playground2);
            playgrounds.Add(playground3);
            playgrounds.Add(playground4);

            DryingTimeCalculator dryingTimeCalculator = new DryingTimeCalculator(wetnessScore.Object, Mock.Of<ILogger<DryingTimeCalculator>>());
            wetnessScore.Setup(service => service.GetWetnessScore(wetnessInfos)).Returns(0.033);

            playgrounds = dryingTimeCalculator.GetPlaygrounds(wetnessInfos, dryingInfos, playgrounds);

            foreach (Playground playground in playgrounds)
            {
                Assert.IsTrue(playground.DryTime != -1);
            }
        }

        [Test]
        [Category("UnitTest")]
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


            WetnessInfo wetnessInfoToday = new WetnessInfo
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
            wetnessInfos.Add(wetnessInfoToday);
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

            List<Playground> playgrounds = new List<Playground>();

            Playground playground1 = new Playground
            {
                Name = "Ocelova smykalka",
                Material = PlaygroundHandler.Enums.Materials.Metal,
                Description = "foo",
                DryTime = 0
            };

            Playground playground2 = new Playground
            {
                Name = "Pieskovisko",
                Material = PlaygroundHandler.Enums.Materials.Sand,
                Description = "foo",
                DryTime = 0
            };

            Playground playground3 = new Playground
            {
                Name = "Hojdaci konik",
                Material = PlaygroundHandler.Enums.Materials.Metal,
                Description = "foo",
                DryTime = 0
            };

            Playground playground4 = new Playground
            {
                Name = "Preliezacka",
                Material = PlaygroundHandler.Enums.Materials.Plastic,
                Description = "foo",
                DryTime = 0
            };

            playgrounds.Add(playground1);
            playgrounds.Add(playground2);
            playgrounds.Add(playground3);
            playgrounds.Add(playground4);

            DryingTimeCalculator dryingTimeCalculator = new DryingTimeCalculator(wetnessScore.Object, Mock.Of<ILogger<DryingTimeCalculator>>());
            wetnessScore.Setup(service => service.GetWetnessScore(wetnessInfos)).Returns(0.708);

            playgrounds = dryingTimeCalculator.GetPlaygrounds(wetnessInfos, dryingInfos, playgrounds);

            foreach (Playground playground in playgrounds)
            {
                Assert.IsTrue(playground.DryTime == -1);
            }
        }
    }


}