using service.Models.Response;

namespace ClothesHandler.Stages
{
    internal class StagesFactory
    {
        private readonly ResponseCurrentForecast _responseCurrentForecast;

        public StagesFactory(ResponseCurrentForecast responseCurrentForecast) 
        {
            _responseCurrentForecast = responseCurrentForecast;
        }

        public List<DefaultBodyPartStage> StageOrder()
        {
            List<DefaultBodyPartStage> defaultBodyPartStages = new List<DefaultBodyPartStage>();

            DefaultBodyPartStage HeadStage = new HeadStage(_responseCurrentForecast);
            DefaultBodyPartStage LegsStage = new LegsStage(_responseCurrentForecast);
            DefaultBodyPartStage BodyStage = new BodyStage(_responseCurrentForecast);
            DefaultBodyPartStage ShoesStage = new ShoesStage(_responseCurrentForecast);
            DefaultBodyPartStage AccessoriesStage = new AccessoriesStage(_responseCurrentForecast);

            defaultBodyPartStages.Add(HeadStage);
            defaultBodyPartStages.Add(BodyStage);
            defaultBodyPartStages.Add(LegsStage);
            defaultBodyPartStages.Add(ShoesStage);
            defaultBodyPartStages.Add(AccessoriesStage);

            return defaultBodyPartStages;
        }
    }
}
