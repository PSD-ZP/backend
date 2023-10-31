using ClothesHandler.Models;
using ClothesHandler.Stages;

namespace ClothesHandler.Calculator
{
    public class RecommendationCalculator : IRecommendationCalculator
    {
        public RecommendationCalculator()
        {
        }

        public BodyPart GetClothes(double temp, double wind, double chanceOfRain, double clouds, double changeOfSnows)
        {
            BodyPart bodyPart = new BodyPart();
            CurrentForecast currentForecast = new CurrentForecast(temp, wind, chanceOfRain, clouds, changeOfSnows);
            StagesFactory stagesFactory = new StagesFactory(currentForecast);

            List<DefaultBodyPartStage> defaultBodyPartStages = stagesFactory.StageOrder();

            bodyPart.Head = defaultBodyPartStages.Where(stage => stage is HeadStage).First().GetClothesItem();
            bodyPart.Body = defaultBodyPartStages.Where(stage => stage is BodyStage).First().GetClothesItem();
            bodyPart.Legs = defaultBodyPartStages.Where(stage => stage is LegsStage).First().GetClothesItem();
            bodyPart.Shoes = defaultBodyPartStages.Where(stage => stage is ShoesStage).First().GetClothesItem();
            bodyPart.Accessories = defaultBodyPartStages.Where(stage => stage is AccessoriesStage).First().GetClothesItem();

            return bodyPart;
        }
    }
}
