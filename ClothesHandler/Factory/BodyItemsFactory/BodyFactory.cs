using ClothesHandler.Enums;
using ClothesHandler.Factory.MaterialsFactory;
using ClothesHandler.Models;

namespace ClothesHandler.Factory.BodyItemsFactory
{
    internal static class BodyFactory
    {
        public static ClothesItem GetBodyItem(BodyEnum clothingType)
        {
            switch (clothingType)
            {
                case BodyEnum.Thin_Bodysuits:
                    return new ClothesItem
                    {
                        Name = "Tenké body",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Cotton),
                        ItemThicknessMm = 3,
                        BodyCoveragePercent = 80
                    };
                case BodyEnum.Solid_Bodysuits:
                    return new ClothesItem
                    {
                        Name = "Hrubé body",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Cotton),
                        ItemThicknessMm = 7.5,
                        BodyCoveragePercent = 95
                    };
                case BodyEnum.TShirt:
                    return new ClothesItem
                    {
                        Name = "Tričko",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Cotton),
                        ItemThicknessMm = 7.5,
                        BodyCoveragePercent = 80
                    };
                case BodyEnum.Sweatshirt:
                    return new ClothesItem
                    {
                        Name = "Mikina",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Cotton),
                        ItemThicknessMm = 10,
                        BodyCoveragePercent = 95
                    };
                case BodyEnum.Transitional_Jacket:
                    return new ClothesItem
                    {
                        Name = "Prechodná bunda",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Cotton),
                        ItemThicknessMm = 10,
                        BodyCoveragePercent = 95
                    };
                case BodyEnum.Softshell_Jacket:
                    return new ClothesItem
                    {
                        Name = "Softshell bunda",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Softshell),
                        ItemThicknessMm = 5,
                        BodyCoveragePercent = 95
                    };
                case BodyEnum.Winter_Jacket:
                    return new ClothesItem
                    {
                        Name = "Zimná bunda",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Cotton),
                        ItemThicknessMm = 15,
                        BodyCoveragePercent = 95
                    };
                default:
                    throw new ArgumentException("Invalid body type");
            }
        }
    }
}
