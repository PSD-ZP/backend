
namespace ClothesHandler.Models
{
    public class Material
    {
       public string Name { get; set; } = default!;

       public double TemperatureLeakiness { get; set; }

       public double WindResistance { get; set; }

       public double WaterResistance { get; set; }
    }
}
