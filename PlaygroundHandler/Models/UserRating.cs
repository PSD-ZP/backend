namespace PlaygroundHandler.Models
{
    public class UserRating
    {
        public int Rating { get; set; } = 0;

        public string Comment { get; set; } = default!;

        public string FromUser { get; set; } = default!;

        public string DateAdded { get; set; } = default!;
    }
}
