using ClothesHandler.Enums;
using ClothesHandler.Factory.MaterialsFactory;
using ClothesHandler.Models;

namespace ClothesHandler.Factory.BodyItemsFactory
{
    internal static class LegsFactory
    {
        public static ClothesItem GetLegsItem(LegsEnum clothingType)
        {
            switch (clothingType)
            {
                case LegsEnum.Shorts:
                    return new ClothesItem
                    {
                        Name = "Kraťasy",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Cotton),
                        BodyCoveragePercent = 25
                    };
                case LegsEnum.Trousers:
                    return new ClothesItem
                    {
                        Name = "Rifle",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Denim),
                        ItemThicknessMm = 5,
                        BodyCoveragePercent = 95
                    };
                case LegsEnum.Underpants:
                    return new ClothesItem
                    {
                        Name = "Spodky",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Cotton),
                        ItemThicknessMm = 4,
                        BodyCoveragePercent = 95
                    };
                default:
                    throw new ArgumentException("Invalid clothing type");
            }
        }
    }
}
