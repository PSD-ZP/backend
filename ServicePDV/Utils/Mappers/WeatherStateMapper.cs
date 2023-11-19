using System.Collections.Generic;

namespace ServicePDV.Utils.Mappers
{
    public static class WeatherStateMapper
    {

        public static string translateEnglishWeatherStateToSlovak(string englishWeatherState)
        {
            switch (englishWeatherState)
            {
                case "Sunny":
                    return "Slnečno";
                case "Partly cloudy":
                    return "Mierne zamračené";
                case "Cloudy":
                case "Overcast":
                    return "Zamračené";
                case "Mist":
                case "Fog":
                case "Freezing fog":
                    return "Hmla";
                case "Patchy rain possible":
                    return "Občasný dážď";
                case "Patchy snow possible":
                case "Patchy sleet possible":
                    return "Občasné sneženie";
                case "Patchy freezing drizzle possible":
                    return "Jemné mrholenie";
                case "Thundery outbreaks possible":
                    return "Búrka";
                case "Blowing snow":
                    return "Sneženie";
                case "Blizzard":
                    return "Snežná búrka";
                case "Patchy light drizzle":
                case "Light drizzle":
                    return "Mrholenie";
                case "Freezing drizzle":
                case "Heavy freezing drizzle":
                    return "Mrznúce mrholenie";
                case "Patchy light rain":
                case "Light rain":
                case "Light rain shower":
                    return "Slabý dážď";
                case "Moderate rain at times":
                case "Moderate rain":
                    return "Mierny dážď";
                case "Heavy rain at times":
                case "Heavy rain":
                case "Moderate or heavy rain shower":
                    return "Silný dážď";
                case "Light freezing rain":
                case "Moderate or heavy freezing rain":
                    return "Mrznúci dážď";
                case "Light sleet":
                case "Moderate or heavy sleet":
                case "Patchy light snow":
                case "Light snow":
                case "Patchy moderate snow":
                case "Moderate snow":
                case "Patchy heavy snow":
                case "Heavy snow":
                case "Ice pellets":
                    return "Sneženie";
                case "Torrential rain shower":
                    return "Prívalový dážď";
                case "Light sleet showers":
                case "Moderate or heavy sleet showers":
                case "Light snow showers":
                case "Moderate or heavy snow showers":
                case "Light showers of ice pellets":
                case "Moderate or heavy showers of ice pellets":
                    return "Snehové prehánky";
                case "Patchy light rain with thunder":
                case "Moderate or heavy rain with thunder":
                    return "Búrka";
                case "Patchy light snow with thunder":
                case "Moderate or heavy snow with thunder":
                    return "Snehová búrka";

                default:
                    return "";
            }

        }

    }
}
