using PlaygroundWeatherState.Models;

namespace ServicePDV.Models.Response
{
    public class ResponseDryingInfo
    {
        public List<WetnessInfo> AvgWetnessInfos { get; }

        public List<DryingInfo> DryingInfos { get; }

        public ResponseDryingInfo(List<WetnessInfo> avgWetnessInfos, List<DryingInfo> dryingInfos)
        {
            AvgWetnessInfos = avgWetnessInfos;
            DryingInfos = dryingInfos;
        }
    }
}
