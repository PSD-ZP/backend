
namespace ClothesHandler.Models
{
    public class BodyPart
    {
        public List<ClothesItem> Head { get; set; } = default!;
        public List<ClothesItem> Body { get; set; } = default!;
        public List<ClothesItem> Legs { get; set; } = default!;
        public List<ClothesItem> Shoes { get; set; } = default!;
        public List<ClothesItem> Accessories { get; set; } = default!;
    }
}
