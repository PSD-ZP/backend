using PlaygroundHandler.Enums;

namespace PlaygroundHandler.Models
{
    public class Playground
    {
        public string Name { get; set; } = default!;

        public Materials Material { get; set; } = default!;

        public double DryTime { get; set; }

        public string Description { get; set; }
    }
}
