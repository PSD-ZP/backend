using ClothesHandler.Calculator;
using ClothesHandler.Enums;
using ClothesHandler.Factory.BodyItemsFactory;
using ClothesHandler.Models;

namespace ClothesHandler.Stages
{
    internal class AccessoriesStage : DefaultBodyPartStage
    {
        public AccessoriesStage(CurrentForecast currentForecast) : base(currentForecast)
        {
        }

        public override List<ClothesItem> GetClothesItem()
        {
            bool isRaining = _currentForecast.ChanceOfRain > 85;
            bool isSnowing = _currentForecast.ChanceOfSnow > 85;

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
