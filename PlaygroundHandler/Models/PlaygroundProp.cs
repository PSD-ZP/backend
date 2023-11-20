using PlaygroundHandler.Enums;

namespace PlaygroundHandler.Models
{
    public class PlaygroundProp
    {
        public string Name { get; set; } = default!;

        public Materials Material { get; set; } = default!;

        public string PathToPlaygroundPropIcon { get; set; } = default!;
    }
}
