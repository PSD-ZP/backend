using ClothesHandler.Enums;
using ClothesHandler.Factory.BodyItemsFactory;
using ClothesHandler.Models;

namespace ClothesHandler.Stages
{
    internal class HeadStage : DefaultBodyPartStage
    {
        public HeadStage(CurrentForecast currentForecast) : base(currentForecast)
        {
        }

        public override List<ClothesItem> GetClothesItem()
        {
            bool isSnowing = _currentForecast.ChanceOfSnow > 85;
            double temperature = _currentForecast.Temperature;
            double clouds = _currentForecast.Clouds;
            double wind = _currentForecast.WindKmph;

            List<ClothesItem> clothesItem = new List<ClothesItem>();

            if (isSnowing || temperature < 14)
            {
                clothesItem.Add(HeadFactory.GetHeadItem(HeadEnum.Winter_Hat));
            }
            else if (temperature > 23 && clouds < 20)
            {
                clothesItem.Add(HeadFactory.GetHeadItem(HeadEnum.Cap));
            }
            else if (temperature > 14 && temperature < 20 && wind > 11)
            {
                clothesItem.Add(HeadFactory.GetHeadItem(HeadEnum.Thin_Hat));
            }
            else
            {
                clothesItem.Add(HeadFactory.GetHeadItem(HeadEnum.EmptyHat));
                clothesItem.Add(HeadFactory.GetHeadItem(HeadEnum.Cap));
            }

            return clothesItem;
        }
    }
}
