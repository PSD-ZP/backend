
namespace ClothesHandler.Models
{
    public class ClothesItem
    {
        public string Name { get; set; } = default!;

        public Material Material { get; set; } = default!;

        public double ItemThicknessMm { get; set; }

        public double BodyCoveragePercent { get; set; }
    }
}
