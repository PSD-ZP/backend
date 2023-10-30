using ClothesHandler.Calculator;
using ClothesHandler.Enums;
using ClothesHandler.Factory.BodyItemsFactory;
using ClothesHandler.Models;

namespace ClothesHandler.Stages
{
    internal class LegsStage : DefaultBodyPartStage
    {
        public LegsStage(CurrentForecast currentForecast) : base(currentForecast)
        {
        }

        public override List<ClothesItem> GetClothesItem()
        {
            double temperature = _currentForecast.Temperature;
            double wind = _currentForecast.WindKmph;

            List<ClothesItem> clothesItem = new List<ClothesItem>();

            if (temperature > 24 && wind < 17)
            {
                clothesItem.Add(LegsFactory.GetLegsItem(LegsEnum.Shorts));
                clothesItem.Add(LegsFactory.GetLegsItem(LegsEnum.Trousers));
            }
            else if (temperature > 5 && temperature < 11 && wind > 20)
            {
                clothesItem.Add(LegsFactory.GetLegsItem(LegsEnum.Underpants));
                clothesItem.Add(LegsFactory.GetLegsItem(LegsEnum.Trousers));
            }
            else if (temperature < 9)
            {
                clothesItem.Add(LegsFactory.GetLegsItem(LegsEnum.Underpants));
                clothesItem.Add(LegsFactory.GetLegsItem(LegsEnum.Trousers));
            }
            else
            {
                clothesItem.Add(LegsFactory.GetLegsItem(LegsEnum.Trousers));
            }

            return clothesItem;
        }
    }
}
