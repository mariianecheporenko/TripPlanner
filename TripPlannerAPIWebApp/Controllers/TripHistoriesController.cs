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
    public class TripHistoriesController : ControllerBase
    {
        private readonly TripPlannerContext _context;

        public TripHistoriesController(TripPlannerContext context)
        {
            _context = context;
        }

        // GET: api/TripHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripHistory>>> GetTripHistories()
        {
            return await _context.TripHistories.ToListAsync();
        }

        // GET: api/TripHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TripHistory>> GetTripHistory(Guid id)
        {
            var tripHistory = await _context.TripHistories.FindAsync(id);

            if (tripHistory == null)
            {
                return NotFound();
            }

            return tripHistory;
        }

        // PUT: api/TripHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTripHistory(Guid id, TripHistory tripHistory)
        {
            if (id != tripHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(tripHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripHistoryExists(id))
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

        // POST: api/TripHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TripHistory>> PostTripHistory(TripHistory tripHistory)
        {
            _context.TripHistories.Add(tripHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTripHistory", new { id = tripHistory.Id }, tripHistory);
        }

        // DELETE: api/TripHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripHistory(Guid id)
        {
            var tripHistory = await _context.TripHistories.FindAsync(id);
            if (tripHistory == null)
            {
                return NotFound();
            }

            _context.TripHistories.Remove(tripHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripHistoryExists(Guid id)
        {
            return _context.TripHistories.Any(e => e.Id == id);
        }
    }
}
