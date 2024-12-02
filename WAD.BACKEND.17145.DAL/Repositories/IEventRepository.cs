using WAD.BACKEND._17145.Models;

namespace WAD.BACKEND._17145.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Events>> GetEvents();
        Task<Events> GetEventId(int id);
        Task PostEvent(Events events);
        Task PutEvent(Events events);
        Task DeleteEvent(int id);
    }
}
