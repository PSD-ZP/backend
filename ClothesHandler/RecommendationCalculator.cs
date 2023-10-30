using ClothesHandler.Models;
using ClothesHandler.Stages;
using service.Models.Response;

namespace ClothesHandler
{
    public class RecommendationCalculator
    {
        private protected readonly ResponseCurrentForecast _responseCurrentForecast;
        public RecommendationCalculator(ResponseCurrentForecast responseCurrentForecast) 
        {
            _responseCurrentForecast = responseCurrentForecast;
        }

        public BodyPart GetClothes()
        {
            BodyPart bodyPart = new BodyPart();
            StagesFactory stagesFactory = new StagesFactory(_responseCurrentForecast);

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
