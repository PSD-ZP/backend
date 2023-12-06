using ClothesHandler.Models;

namespace ClothesHandler.Stages
{
    internal class StagesFactory
    {
        private readonly CurrentForecast _currentForecast;

        public StagesFactory(CurrentForecast currentForecast) 
        {
            _currentForecast = currentForecast;
        }

        public List<DefaultBodyPartStage> StageOrder()
        {
            List<DefaultBodyPartStage> defaultBodyPartStages = new List<DefaultBodyPartStage>();

            DefaultBodyPartStage HeadStage = new HeadStage(_currentForecast);
            DefaultBodyPartStage LegsStage = new LegsStage(_currentForecast);
            DefaultBodyPartStage BodyStage = new BodyStage(_currentForecast);
            DefaultBodyPartStage ShoesStage = new ShoesStage(_currentForecast);
            DefaultBodyPartStage AccessoriesStage = new AccessoriesStage(_currentForecast);

            defaultBodyPartStages.Add(HeadStage);
            defaultBodyPartStages.Add(BodyStage);
            defaultBodyPartStages.Add(LegsStage);
            defaultBodyPartStages.Add(ShoesStage);
            defaultBodyPartStages.Add(AccessoriesStage);

            return defaultBodyPartStages;
        }
    }
}
