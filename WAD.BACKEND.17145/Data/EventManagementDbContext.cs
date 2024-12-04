using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._17145.Models;

namespace WAD.BACKEND._17145.Data
{
    public class EventManagementDbContext:DbContext
    {
        public EventManagementDbContext(DbContextOptions<EventManagementDbContext> options) : base(options) { }

        public DbSet<Events> Events { get; set; }
        public DbSet<Participants> Participants { get; set; }
    }
}
