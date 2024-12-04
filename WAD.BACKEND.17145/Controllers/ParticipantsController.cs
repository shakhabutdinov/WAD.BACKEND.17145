using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // GET: api/Participants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participants>>> GetParticipants()
        {
          if (_context.Participants == null)
          {
              return NotFound();
          }
            return await _context.Participants.ToListAsync();
        }

        // GET: api/Participants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participants>> GetParticipants(int id)
        {
          if (_context.Participants == null)
          {
              return NotFound();
          }
            var participants = await _context.Participants.FindAsync(id);

            if (participants == null)
            {
                return NotFound();
            }

            return participants;
        }

        // PUT: api/Participants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/Participants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participants>> PostParticipants(Participants participants)
        {
          if (_context.Participants == null)
          {
              return Problem("Entity set 'EventManagementDbContext.Participants'  is null.");
          }
            _context.Participants.Add(participants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipants", new { id = participants.Id }, participants);
        }

        // DELETE: api/Participants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipants(int id)
        {
            if (_context.Participants == null)
            {
                return NotFound();
            }
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
            return (_context.Participants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
