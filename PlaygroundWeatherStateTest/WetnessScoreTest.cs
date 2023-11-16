using Moq;
using PlaygroundWeatherState.Models;
using PlaygroundWeatherState.WetnessScoreCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundWeatherStateTest
{
    [TestFixture]
    public class WetnessScoreTest
    {
        [Test]
        [Category("UnitTest")]
        public void WetnessScoreForNoPrecipitationAndRegularHumidity()
        {
            IWetnessScore wetnessScoreCalculator = new WetnessScore();

            List<WetnessInfo> wetnessDuringLast2Days = new List<WetnessInfo>();

            WetnessInfo wetnessInfoYesterday = new WetnessInfo
            {
                Humidity = 70,
                Precipitation = 0,
                Temperature = 20
            };


            WetnessInfo wetnessInfoToday = new WetnessInfo
            {
                Humidity = 70,
                Precipitation = 0,
                Temperature = 20
            };

            wetnessDuringLast2Days.Add(wetnessInfoYesterday);
            wetnessDuringLast2Days.Add(wetnessInfoToday);

            double wetnessScore = wetnessScoreCalculator.GetWetnessScore(wetnessDuringLast2Days);
            
            Console.WriteLine(wetnessScore);
            // No precipitation so should wetness score should be lower than 0.3
            Assert.IsTrue(wetnessScore < 0.3);
        }
 
        [Test]
        [Category("UnitTest")]
        public void WetnessScoreForHighPrecipitationAndHighHumidity()
        {
            IWetnessScore wetnessScoreCalculator = new WetnessScore();

            List<WetnessInfo> wetnessDuringLast2Days = new List<WetnessInfo>();

            WetnessInfo wetnessInfo = new WetnessInfo
            {
                Humidity = 80,
                Precipitation = 20,
                Temperature = 20
            };


            WetnessInfo wetnessInfoToday = new WetnessInfo
            {
                Humidity = 80,
                Precipitation = 20,
                Temperature = 20
            };

            wetnessDuringLast2Days.Add(wetnessInfo);
            wetnessDuringLast2Days.Add(wetnessInfoToday);

            double wetnessScore = wetnessScoreCalculator.GetWetnessScore(wetnessDuringLast2Days);

            Console.WriteLine(wetnessScore);
            // Wetness score should be higher than 0.3
            Assert.IsTrue(wetnessScore > 0.3);
        }

        [Test]
        [Category("UnitTest")]
        public void WetnessScoreYesterdayWasRainingAndTodayIsHot()
        {
            IWetnessScore wetnessScoreCalculator = new WetnessScore();

            List<WetnessInfo> wetnessDuringLast2Days = new List<WetnessInfo>();

            WetnessInfo wetnessInfoYesterday = new WetnessInfo
            {
                Humidity = 80,
                Precipitation = 15,
                Temperature = 18
            };


            WetnessInfo wetnessInfoToday = new WetnessInfo
            {
                Humidity = 60,
                Precipitation = 0,
                Temperature = 28
            };

            wetnessDuringLast2Days.Add(wetnessInfoToday);
            wetnessDuringLast2Days.Add(wetnessInfoYesterday);
            double wetnessScore = wetnessScoreCalculator.GetWetnessScore(wetnessDuringLast2Days);

            Console.WriteLine(wetnessScore);
            // Wetness score should be higher than 0.3
            Assert.IsTrue(wetnessScore < 0.3);
        }

        [Test]
        [Category("UnitTest")]
        public void WetnessScoreYesterdaySunnyAndTodayIsRaining()
        {
            IWetnessScore wetnessScoreCalculator = new WetnessScore();

            List<WetnessInfo> wetnessDuringLast2Days = new List<WetnessInfo>();

            WetnessInfo wetnessInfoYesterday = new WetnessInfo
            {
                Humidity = 50,
                Precipitation = 0,
                Temperature = 31
            };


            WetnessInfo wetnessInfoToday = new WetnessInfo
            {
                Humidity = 78,
                Precipitation = 5,
                Temperature = 25
            };

            wetnessDuringLast2Days.Add(wetnessInfoToday);
            wetnessDuringLast2Days.Add(wetnessInfoYesterday);
            double wetnessScore = wetnessScoreCalculator.GetWetnessScore(wetnessDuringLast2Days);

            Console.WriteLine(wetnessScore);
            // Wetness score should be higher than 0.3
            Assert.IsTrue(wetnessScore > 0.3);
        }

        [Test]
        [Category("UnitTest")]
        public void WetnessScoreWinterYesterdayColdAndSunnyAndTodayIsColdAndSnowy()
        {
            IWetnessScore wetnessScoreCalculator = new WetnessScore();

            List<WetnessInfo> wetnessDuringLast2Days = new List<WetnessInfo>();

            WetnessInfo wetnessInfoYesterday = new WetnessInfo
            {
                Humidity = 45,
                Precipitation = 0,
                Temperature = -5
            };


            WetnessInfo wetnessInfoToday = new WetnessInfo
            {
                Humidity = 50,
                Precipitation = 10,
                Temperature = -7
            };

            wetnessDuringLast2Days.Add(wetnessInfoToday);
            wetnessDuringLast2Days.Add(wetnessInfoYesterday);
            double wetnessScore = wetnessScoreCalculator.GetWetnessScore(wetnessDuringLast2Days);

            Console.WriteLine(wetnessScore);
            // Wetness score should be higher than 0.3
            Assert.IsTrue(wetnessScore > 0.3);
        }

        [Test]
        [Category("UnitTest")]
        public void WetnessScoreAutumnYesterdayWasWholeDayRainingAndTodayIsCloudyHighHumidityDayWithoutRain()
        {
            IWetnessScore wetnessScoreCalculator = new WetnessScore();

            List<WetnessInfo> wetnessDuringLast2Days = new List<WetnessInfo>();

            WetnessInfo wetnessInfoYesterday = new WetnessInfo
            {
                Humidity = 80,
                Precipitation = 10,
                Temperature = 11
            };


            WetnessInfo wetnessInfoToday = new WetnessInfo
            {
                Humidity = 70,
                Precipitation = 0,
                Temperature = 11
            };

            wetnessDuringLast2Days.Add(wetnessInfoToday);
            wetnessDuringLast2Days.Add(wetnessInfoYesterday);
            double wetnessScore = wetnessScoreCalculator.GetWetnessScore(wetnessDuringLast2Days);

            Console.WriteLine(wetnessScore);
            // Wetness score should be higher than 0.3
            Assert.IsTrue(wetnessScore > 0.3);
        }
    }

}
