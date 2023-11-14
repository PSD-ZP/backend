using PlaygroundWeatherState.Models;

namespace PlaygroundWeatherState.DryCalculator
{
    public interface IDryingTimeCalculator
    {
        int GetHoursOfDrying(List<WetnessInfo> avgWetnessInfos, List<DryingInfo> dryingInfos);
    }
}
