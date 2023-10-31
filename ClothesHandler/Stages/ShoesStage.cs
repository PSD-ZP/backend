using ClothesHandler.Calculator;
using ClothesHandler.Enums;
using ClothesHandler.Factory.BodyItemsFactory;
using ClothesHandler.Models;

namespace ClothesHandler.Stages
{
    internal class ShoesStage : DefaultBodyPartStage
    {
        public ShoesStage(CurrentForecast currentForecast) : base(currentForecast)
        {
        }

        public override List<ClothesItem> GetClothesItem()
        {
            bool isRaining = _currentForecast.ChanceOfRain > 85;
            double temperature = _currentForecast.Temperature;

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
