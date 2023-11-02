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


            bodyPart.Head = defaultBodyPartStages.First(stage => stage is HeadStage).GetClothesItem();
            bodyPart.Body = defaultBodyPartStages.First(stage => stage is BodyStage).GetClothesItem();
            bodyPart.Legs = defaultBodyPartStages.First(stage => stage is LegsStage).GetClothesItem();
            bodyPart.Shoes = defaultBodyPartStages.First(stage => stage is ShoesStage).GetClothesItem();
            bodyPart.Accessories = defaultBodyPartStages.First(stage => stage is AccessoriesStage).GetClothesItem();

            return bodyPart;
        }
    }
}
