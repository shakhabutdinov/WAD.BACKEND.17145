using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._17145.Data;
using WAD.BACKEND._17145.Models;

namespace WAD.BACKEND._17145.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly EventManagementDbContext _context;

        public ParticipantsController(EventManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participants>>> GetParticipants()
        {
            return await _context.Participants.Include(p => p.Events).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Participants>> GetParticipants(int id)
        {
            var participants = await _context.Participants.Include(p => p.Events).FirstOrDefaultAsync(p => p.Id == id);

            if (participants == null)
            {
                return NotFound();
            }

            return participants;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipants(int id, Participants participants)
        {
            if (id != participants.Id)
            {
                return BadRequest();
            }

            _context.Entry(participants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Participants>> PostParticipants(Participants participants)
        {
            _context.Participants.Add(participants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipants", new { id = participants.Id }, participants);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipants(int id)
        {
            var participants = await _context.Participants.FindAsync(id);
            if (participants == null)
            {
                return NotFound();
            }

            _context.Participants.Remove(participants);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipantsExists(int id)
        {
            return _context.Participants.Any(e => e.Id == id);
        }
    }
}
