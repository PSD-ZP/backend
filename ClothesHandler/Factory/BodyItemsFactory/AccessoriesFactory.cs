using ClothesHandler.Enums;
using ClothesHandler.Factory.MaterialsFactory;
using ClothesHandler.Models;

namespace ClothesHandler.Factory.BodyItemsFactory
{
    internal static class AccessoriesFactory
    {
        public static ClothesItem GetAccessoriesItem(AccessoriesEnum accessoriesType)
        {
            switch (accessoriesType)
            {
                case AccessoriesEnum.Umbrella:
                    return new ClothesItem
                    {
                        Name = "Dáždnik",
                        Material = null!,
                        ItemThicknessMm = 0,
                        BodyCoveragePercent = 0
                    };
                case AccessoriesEnum.Raincoat:
                    return new ClothesItem
                    {
                        Name = "Pršiplašť",
                        Material = null!,
                        ItemThicknessMm = 1,
                        BodyCoveragePercent = 100
                    };
                case AccessoriesEnum.Gloves:
                    return new ClothesItem
                    {
                        Name = "Rukavice",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Wool),
                        ItemThicknessMm = 5,
                        BodyCoveragePercent = 10
                    };
                case AccessoriesEnum.Scarf:
                    return new ClothesItem
                    {
                        Name = "Šál",
                        Material = MaterialFactory.GetMaterial(MaterialsEnum.Wool),
                        ItemThicknessMm = 12,
                        BodyCoveragePercent = 7
                    };
                default:
                    throw new ArgumentException("Invalid accessories type");
            }
        }
    }
}
