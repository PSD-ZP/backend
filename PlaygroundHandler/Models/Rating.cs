namespace PlaygroundHandler.Models
{
    public class Rating
    {
        public double AverageRating { get; set; } = 0;

        public int TimesRated { get; set; } = 0;

        public string PathToRatingIcon { get; set; } = default!;

        public List<UserRating> UserRatings { get; set; } = new List<UserRating>();
    }
}
