using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._17145.Data;
using WAD.BACKEND._17145.Models;

namespace WAD.BACKEND._17145.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventManagementDbContext _dbContext;

        public EventRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteEvent(int id)
        {
            var eventEntity = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (eventEntity != null)
            {
                _dbContext.Events.Remove(eventEntity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Events> GetEventId(int id)
        {
            return await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Events>> GetEvents()
        {
            return await _dbContext.Events.ToListAsync();
        }

        public async Task PostEvent(Events events)
        {
            await _dbContext.Events.AddAsync(events);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutEvent(Events events)
        {
            _dbContext.Entry(events).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
