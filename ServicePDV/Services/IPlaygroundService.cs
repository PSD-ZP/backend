using PlaygroundHandler.Models;

namespace ServicePDV.Services
{
    public interface IPlaygroundService
    {
        Task<List<Playground>> GetPlaygrounds(string city = null);
    }
}
