using ClothesHandler.Calculator;
using ClothesHandler.Enums;
using ClothesHandler.Factory.BodyItemsFactory;
using ClothesHandler.Models;

namespace ClothesHandler.Stages
{
    internal class BodyStage : DefaultBodyPartStage
    {
        public BodyStage(CurrentForecast currentForecast) : base(currentForecast)
        {
        }

        public override List<ClothesItem> GetClothesItem()
        {
            double temperature = _currentForecast.Temperature;
            double wind = _currentForecast.WindKmph;

            List<ClothesItem> clothesItem = new List<ClothesItem>();

            if (temperature < 12)
            {
                clothesItem.Add(BodyFactory.GetBodyItem(BodyEnum.Solid_Bodysuits));
            }
            else if (temperature > 12 && temperature < 18 && wind > 20)
            {
                clothesItem.Add(BodyFactory.GetBodyItem(BodyEnum.Thin_Bodysuits));
            }
            else
            {
                clothesItem.Add(BodyFactory.GetBodyItem(BodyEnum.TShirt));
            }
            
            if (temperature < 22)
            {
                clothesItem.Add(BodyFactory.GetBodyItem(BodyEnum.Sweatshirt));
            }

            if (temperature < 13)
            {
                clothesItem.Add(BodyFactory.GetBodyItem(BodyEnum.Winter_Jacket));
            }
            else if (temperature > 14 && temperature < 19 && wind > 15)
            {
                clothesItem.Add(BodyFactory.GetBodyItem(BodyEnum.Softshell_Jacket));
            }
            else if (temperature > 13 && temperature < 18)
            {
                clothesItem.Add(BodyFactory.GetBodyItem(BodyEnum.Transitional_Jacket));
            }

            return clothesItem;
        }
    }
}
