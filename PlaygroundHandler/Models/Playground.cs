namespace PlaygroundHandler.Models
{
    public class Playground
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string City { get; set; } = default!;

        public string Address { get; set; } = default!;

        public Rating Rating { get; set; } = default!;

        public List<PlaygroundProp> PlaygroundProps { get; set; } = new List<PlaygroundProp>();
    }
}
