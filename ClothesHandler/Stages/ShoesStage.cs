using ClothesHandler.Enums;
using ClothesHandler.Factory.BodyItemsFactory;
using ClothesHandler.Models;
using service.Models.Response;

namespace ClothesHandler.Stages
{
    internal class ShoesStage : DefaultBodyPartStage
    {
        public ShoesStage(ResponseCurrentForecast responseCurrentForecast) : base(responseCurrentForecast)
        {
        }

        public override List<ClothesItem> GetClothesItem()
        {
            bool isRaining = _responseCurrentForecast.ChanceOfRain > 85;
            double temperature = _responseCurrentForecast.Temperature;

            List<ClothesItem> clothesItem = new List<ClothesItem>();

            if (temperature < 12)
            {
                clothesItem.Add(ShoesFactory.GetShoesItem(ShoesEnum.Winter_Boots));
            }
            else if (isRaining)
            {
                clothesItem.Add(ShoesFactory.GetShoesItem(ShoesEnum.Rain_Boots));
            }
            else if (temperature > 25 && !isRaining)
            {
                clothesItem.Add(ShoesFactory.GetShoesItem(ShoesEnum.Sandals));
                clothesItem.Add(ShoesFactory.GetShoesItem(ShoesEnum.Trainers));
            }
            else
            {
                clothesItem.Add(ShoesFactory.GetShoesItem(ShoesEnum.Trainers));
            }

            return clothesItem;
        }
    }
}
