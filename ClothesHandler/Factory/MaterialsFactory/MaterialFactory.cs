using ClothesHandler.Enums;
using ClothesHandler.Models;

namespace ClothesHandler.Factory.MaterialsFactory
{
    internal static class MaterialFactory
    {
        public static Material GetMaterial(MaterialsEnum materialType)
        {
            switch (materialType)
            {
                case MaterialsEnum.Cotton:
                    return new Material
                    {
                        Name = "Bavlna",
                        TemperatureLeakiness = 60,
                        WindResistance = 30,
                        WaterResistance = 10
                    };
                case MaterialsEnum.Denim:
                    return new Material
                    {
                        Name = "Rifľovina",
                        TemperatureLeakiness = 40,
                        WindResistance = 50,
                        WaterResistance = 30
                    };
                case MaterialsEnum.Wool:
                    return new Material
                    {
                        Name = "Vlna",
                        TemperatureLeakiness = 30,
                        WindResistance = 50,
                        WaterResistance = 10
                    };
                case MaterialsEnum.Rubber:
                    return new Material
                    {
                        Name = "Guma",
                        TemperatureLeakiness = 50,
                        WindResistance = 100,
                        WaterResistance = 100
                    };
                case MaterialsEnum.Leather:
                    return new Material
                    {
                        Name = "Koža",
                        TemperatureLeakiness = 30,
                        WindResistance = 80,
                        WaterResistance = 30
                    };
                case MaterialsEnum.Softshell:
                    return new Material
                    {
                        Name = "Softshell",
                        TemperatureLeakiness = 30,
                        WindResistance = 90,
                        WaterResistance = 80
                    };
                default:
                    throw new ArgumentException("Invalid material type");
            }
        }
    }
}
