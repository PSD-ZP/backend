using ClothesHandler.Enums;
using ClothesHandler.Factory.MaterialsFactory;
using ClothesHandler.Models;

namespace ClothesHandler.Factory.BodyItemsFactory
{
    internal static class HeadFactory
    {
        public static ClothesItem GetHeadItem(HeadEnum clothingType)
        {
            switch (clothingType)
            {
                case HeadEnum.Winter_Hat:
                    return new ClothesItem
                    {
                        Name = "Zimna čiapka",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Wool),
                        ItemThicknessMm = 12,
                        BodyCoveragePercent = 75
                    };
                case HeadEnum.Thin_Hat:
                    return new ClothesItem
                    {
                        Name = "Prechodna čiapka",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Cotton),
                        ItemThicknessMm = 8,
                        BodyCoveragePercent = 70
                    };
                case HeadEnum.Cap:
                    return new ClothesItem
                    {
                        Name = "Šiltovka",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Cotton),
                        ItemThicknessMm = 3,
                        BodyCoveragePercent = 60
                    };
                case HeadEnum.EmptyHat:
                    return new ClothesItem
                    {
                        Name = "NONE",
                        Material = null!,
                        ItemThicknessMm = 0,
                        BodyCoveragePercent = 0
                    };
                default:
                    throw new ArgumentException("Invalid head type");
            }
        }
    }
}
