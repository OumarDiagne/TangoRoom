using TangoRoom.Server.Models;

namespace TangoRoom.Server.Interfaces
{
    public interface IMarathonService
    {
        Task<List<Marathon>> GetMarathons();
        Task<Marathon?> GetMarathon(int id);
    }
}
