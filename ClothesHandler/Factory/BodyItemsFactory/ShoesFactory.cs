using ClothesHandler.Enums;
using ClothesHandler.Factory.MaterialsFactory;
using ClothesHandler.Models;

namespace ClothesHandler.Factory.BodyItemsFactory
{
    internal static class ShoesFactory
    {
        public static ClothesItem GetShoesItem(ShoesEnum clothingType)
        {
            switch (clothingType)
            {
                case ShoesEnum.Sandals:
                    return new ClothesItem
                    {
                        Name = "Sandále",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Leather),
                        ItemThicknessMm = 5,
                        BodyCoveragePercent = 15
                    };
                case ShoesEnum.Trainers:
                    return new ClothesItem
                    {
                        Name = "Tenisky",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Leather),
                        ItemThicknessMm = 5,
                        BodyCoveragePercent = 80
                    };
                case ShoesEnum.Rain_Boots:
                    return new ClothesItem
                    {
                        Name = "Gumáky",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Rubber),
                        ItemThicknessMm = 5,
                        BodyCoveragePercent = 100
                    };
                case ShoesEnum.Winter_Boots:
                    return new ClothesItem
                    {
                        Name = "Zimné topánky",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Leather),
                        ItemThicknessMm = 8,
                        BodyCoveragePercent = 95
                    };
                default:
                    throw new ArgumentException("Invalid clothing type");
            }
        }
    }
}
