using PlaygroundHandler.Models;
using ServicePVD.Models.Request;

namespace ServicePDV.Services
{
    public interface IPlaygroundService
    {
        Task<List<Playground>> GetPlaygrounds(RequestCoordinates coordinates);
    }
}
