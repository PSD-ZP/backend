using PlaygroundWeatherState.Models;

namespace PlaygroundWeatherState.WetnessScoreCalculator
{
    public interface IWetnessScore
    {
        double GetWetnessScore(List<WetnessInfo> avgWetnessInfos);
    }
}
