using PlaygroundHandler.Models;
using PlaygroundWeatherState.Models;

namespace PlaygroundWeatherState.DryCalculator
{
    public interface IDryingTimeCalculator
    {
        List<Playground> GetPlaygrounds(List<WetnessInfo> avgWetnessInfos, List<DryingInfo> dryingInfos, List<Playground> playgrounds);
    }
}
