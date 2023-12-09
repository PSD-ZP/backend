using ClothesHandler.Models;

namespace ClothesHandler.Stages
{
    internal abstract class DefaultBodyPartStage
    {
        private protected readonly CurrentForecast _currentForecast;

        protected DefaultBodyPartStage(CurrentForecast currentForecast) 
        {
            _currentForecast = currentForecast;
        }


        public abstract List<ClothesItem> GetClothesItem();
    }
}
