using ClothesHandler.Models;
using service.Models.Response;

namespace ClothesHandler.Stages
{
    internal abstract class DefaultBodyPartStage
    {
        private protected readonly ResponseCurrentForecast _responseCurrentForecast;

        protected DefaultBodyPartStage(ResponseCurrentForecast responseCurrentForecast) 
        {
            _responseCurrentForecast = responseCurrentForecast;
        }


        public abstract List<ClothesItem> GetClothesItem();
    }
}
