using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._17145.Data;
using WAD.BACKEND._17145.Models;

namespace WAD.BACKEND._17145.Repositories
{
    public class ParticipantsRepository : IParticipantsRepository
    {
        private readonly EventManagementDbContext _dbContext;

        public ParticipantsRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteParticipants(int id)
        {
            var participants = await _dbContext.Participants.FirstOrDefaultAsync(p => p.Id == id);

            if (participants != null)
            {
                _dbContext.Participants.Remove(participants);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Participants> GetParticipantsById(int id)
        {
            return await _dbContext.Participants.Include(p => p.Events).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Participants>> GetParticipants()
        {
            return await _dbContext.Participants.Include(p => p.Events).ToListAsync();
        }

        public async Task PostParticipants(Participants participants)
        {
            var eventEntity = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == participants.EventId);

            if (eventEntity != null)
            {
                participants.Events = eventEntity;
                await _dbContext.Participants.AddAsync(participants);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Event not found");
            }
        }

        public async Task PutParticipants(Participants participants)
        {
            _dbContext.Entry(participants).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
