using ClothesHandler.Models;

namespace ClothesHandler.Calculator
{
    public interface IRecommendationCalculator
    {
        BodyPart GetClothes(double temp, double wind, double chanceOfRain, double clouds, double changeOfSnows);
    }
}
