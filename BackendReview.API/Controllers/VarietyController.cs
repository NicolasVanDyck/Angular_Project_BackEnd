using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendReview.DAL.Models;
using Microsoft.AspNetCore.Authorization;

namespace BackendReview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VarietyController : ControllerBase
    {
        private readonly ReviewDbContext _context;

        public VarietyController(ReviewDbContext context)
        {
            _context = context;
        }

        // GET: api/Variety
        [HttpGet]
        [Authorize(Policy = "ReadVariety")]
        public async Task<ActionResult<IEnumerable<Variety>>> GetVarieties()
        {
            return await _context.Varieties.ToListAsync();
        }

        // GET: api/Variety/5
        [HttpGet("{id}")]
        [Authorize(Policy = "ReadVariety")]
        public async Task<ActionResult<Variety>> GetVariety(int id)
        {
            var variety = await _context.Varieties.FindAsync(id);

            if (variety == null)
            {
                return NotFound();
            }

            return variety;
        }

        // PUT: api/Variety/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "UpdateVariety")]
        public async Task<IActionResult> PutVariety(int id, Variety variety)
        {
            if (id != variety.Id)
            {
                return BadRequest();
            }

            _context.Entry(variety).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VarietyExists(id))
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

        // POST: api/Variety
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = "CreateVariety")]
        public async Task<ActionResult<Variety>> PostVariety(Variety variety)
        {
            _context.Varieties.Add(variety);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVariety", new { id = variety.Id }, variety);
        }

        // DELETE: api/Variety/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "DeleteVariety")]
        public async Task<IActionResult> DeleteVariety(int id)
        {
            var variety = await _context.Varieties.FindAsync(id);
            if (variety == null)
            {
                return NotFound();
            }

            _context.Varieties.Remove(variety);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VarietyExists(int id)
        {
            return _context.Varieties.Any(e => e.Id == id);
        }
    }
}
