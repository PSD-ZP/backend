using ClothesHandler.Enums;
using ClothesHandler.Factory.BodyItemsFactory;
using ClothesHandler.Models;
using service.Models.Response;

namespace ClothesHandler.Stages
{
    internal class AccessoriesStage : DefaultBodyPartStage
    {
        public AccessoriesStage(ResponseCurrentForecast responseCurrentForecast) : base(responseCurrentForecast)
        {
        }

        public override List<ClothesItem> GetClothesItem()
        {
            bool isRaining = _responseCurrentForecast.ChanceOfRain > 85;
            bool isSnowing = _responseCurrentForecast.ChanceOfSnow > 85;

            List<ClothesItem> clothesItem = new List<ClothesItem>();

            if (isRaining)
            {
                clothesItem.Add(AccessoriesFactory.GetAccessoriesItem(AccessoriesEnum.Umbrella));
                clothesItem.Add(AccessoriesFactory.GetAccessoriesItem(AccessoriesEnum.Raincoat));
            }

            if (isSnowing)
            {
                clothesItem.Add(AccessoriesFactory.GetAccessoriesItem(AccessoriesEnum.Gloves));
                clothesItem.Add(AccessoriesFactory.GetAccessoriesItem(AccessoriesEnum.Scarf));
            }

            return clothesItem;
        }
    }
}
