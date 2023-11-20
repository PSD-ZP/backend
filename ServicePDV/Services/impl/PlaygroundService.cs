using PlaygroundHandler.Models;
using ServicePVD.Services;

namespace ServicePDV.Services.impl
{
    public class PlaygroundService : IPlaygroundService
    {
        public async Task<List<Playground>> GetPlaygrounds(string city = null)
        {
            List<Playground> playgrounds = new List<Playground>();

            Rating rating = new Rating
            {
                AverageRating = 3,
                PathToRatingIcon = "noPathSpecified/",
                TimesRated = 10,
                UserRatings = new List<UserRating>
                {
                    new UserRating
                    {
                        Comment = "koment",
                        DateAdded = "10.10.2013",
                        FromUser = "Johny",
                        Rating = 4
                    },
                    new UserRating
                    {
                        Comment = "koment 01",
                        DateAdded = "10.12.2025",
                        FromUser = "Jake",
                        Rating = 2
                    }
                }
            };
            
            Playground playground = new Playground
            {
                City = "Kosice",
                Address = "ADRESA",
                Description = "Dobre ihrisko",
                Name = "Ihrisko v Kosiciach",
                Rating = rating,
                PlaygroundProps = new List<PlaygroundProp> { 
                    new PlaygroundProp
                    {
                        Material = PlaygroundHandler.Enums.Materials.Wood,
                        Name = "Preliezka",
                        PathToPlaygroundPropIcon = "NoPathSpecified"
                    },
                    new PlaygroundProp
                    {
                        Material = PlaygroundHandler.Enums.Materials.Metal,
                        Name = "Smykalka",
                        PathToPlaygroundPropIcon = "NoPathSpecified"
                    }
                }
            };

            playgrounds.Add(playground);

            return playgrounds;
        }

    }
}
