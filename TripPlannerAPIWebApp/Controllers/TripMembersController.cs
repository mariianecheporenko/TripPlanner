using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripPlannerAPI.Data;
using TripPlannerAPI.Models;

namespace TripPlannerAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripMembersController : ControllerBase
    {
        private readonly TripPlannerContext _context;

        public TripMembersController(TripPlannerContext context)
        {
            _context = context;
        }

        // GET: api/TripMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripMember>>> GetTripMembers()
        {
            return await _context.TripMembers.ToListAsync();
        }

        // GET: api/TripMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TripMember>> GetTripMember(Guid id)
        {
            var tripMember = await _context.TripMembers.FindAsync(id);

            if (tripMember == null)
            {
                return NotFound();
            }

            return tripMember;
        }

        // PUT: api/TripMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTripMember(Guid id, TripMember tripMember)
        {
            if (id != tripMember.Id)
            {
                return BadRequest();
            }

            _context.Entry(tripMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripMemberExists(id))
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

        // POST: api/TripMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TripMember>> PostTripMember(TripMember tripMember)
        {
            // Member duplication
            var exists = await _context.TripMembers
                .AnyAsync(m => m.TripId == tripMember.TripId && m.UserId == tripMember.UserId);

            if (exists)
            {
                return Conflict("Цей користувач уже є учасником поїздки.");
            }

            _context.TripMembers.Add(tripMember);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTripMember", new { id = tripMember.Id }, tripMember);
        }

        // DELETE: api/TripMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripMember(Guid id)
        {
            var tripMember = await _context.TripMembers.FindAsync(id);
            if (tripMember == null)
            {
                return NotFound();
            }

            _context.TripMembers.Remove(tripMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripMemberExists(Guid id)
        {
            return _context.TripMembers.Any(e => e.Id == id);
        }
    }
}
