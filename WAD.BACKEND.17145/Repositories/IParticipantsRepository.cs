using WAD.BACKEND._17145.Models;

namespace WAD.BACKEND._17145.Repositories
{
    public interface IParticipantsRepository
    {
        Task<IEnumerable<Participants>> GetParticipants();
        Task<Participants> GetParticipantsById(int id);
        Task PostParticipants(Participants participants);
        Task PutParticipants(Participants participants);
        Task DeleteParticipants(int id);
    }
}
