using ClothesHandler.Models;
using ServicePDV.Models.Request;

namespace ServicePVD.Services
{
    public interface IClothesService
    {
        BodyPart GetClothes(RequestWeatherInfo requestWeatherInfo);
    }
}
