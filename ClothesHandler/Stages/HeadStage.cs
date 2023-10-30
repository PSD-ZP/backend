using ClothesHandler.Enums;
using ClothesHandler.Factory.BodyItemsFactory;
using ClothesHandler.Models;
using service.Models.Response;

namespace ClothesHandler.Stages
{
    internal class HeadStage : DefaultBodyPartStage
    {
        public HeadStage(ResponseCurrentForecast responseCurrentForecast) : base(responseCurrentForecast)
        {
        }

        public override List<ClothesItem> GetClothesItem()
        {
            bool isSnowing = _responseCurrentForecast.ChanceOfSnow > 85;
            double temperature = _responseCurrentForecast.Temperature;
            double clouds = _responseCurrentForecast.Clouds;
            double wind = _responseCurrentForecast.WindKmph;

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
