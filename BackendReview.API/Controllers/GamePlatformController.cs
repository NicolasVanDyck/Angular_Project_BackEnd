using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendReview.DAL.Models;

namespace BackendReview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamePlatformController : ControllerBase
    {
        private readonly ReviewDbContext _context;

        public GamePlatformController(ReviewDbContext context)
        {
            _context = context;
        }

        // GET: api/GamePlatform
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamePlatform>>> GetGamePlatforms()
        {
            return await _context.GamePlatforms.Include(g => g.Game).Include(p => p.Platform).ToListAsync();
        }

        // GET: api/GamePlatform/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GamePlatform>> GetGamePlatform(int id)
        {
            var gamePlatform = await _context.GamePlatforms.FindAsync(id);

            if (gamePlatform == null)
            {
                return NotFound();
            }

            return gamePlatform;
        }

        // PUT: api/GamePlatform/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamePlatform(int id, GamePlatform gamePlatform)
        {
            if (id != gamePlatform.Id)
            {
                return BadRequest();
            }

            _context.Entry(gamePlatform).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamePlatformExists(id))
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

        // POST: api/GamePlatform
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GamePlatform>> PostGamePlatform(GamePlatform gamePlatform)
        {
            _context.GamePlatforms.Add(gamePlatform);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamePlatform", new { id = gamePlatform.Id }, gamePlatform);
        }

        // DELETE: api/GamePlatform/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamePlatform(int id)
        {
            var gamePlatform = await _context.GamePlatforms.FindAsync(id);
            if (gamePlatform == null)
            {
                return NotFound();
            }

            _context.GamePlatforms.Remove(gamePlatform);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GamePlatformExists(int id)
        {
            return _context.GamePlatforms.Any(e => e.Id == id);
        }
    }
}
