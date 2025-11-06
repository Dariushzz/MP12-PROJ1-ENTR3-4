using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkingwithSQLLiteinAsp.NETCoreWebAPI.Models;
using WorkingwithSQLLiteinAsp.NETCoreWebAPI.Data;

namespace WorkingwithSQLLiteinAsp.NETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UfcfightersController : ControllerBase
    {
        private readonly MiDbContext _context;

        public UfcfightersController(MiDbContext context)
        {
            _context = context;
        }

        // GET: api/Ufcfighters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ufcfighter>>> GetUfcfighters()
        {
            return await _context.Ufcfighters.ToListAsync();
        }

        // GET: api/Ufcfighters/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Ufcfighter>> GetUfcfighter(string id)
        {
            var fighter = await _context.Ufcfighters.FindAsync(id);
            if (fighter == null)
                return NotFound();

            return fighter;
        }

        // POST: api/Ufcfighters
        [HttpPost]
        public async Task<ActionResult<Ufcfighter>> PostUfcfighter(Ufcfighter fighter)
        {
            _context.Ufcfighters.Add(fighter);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUfcfighter), new { id = fighter.Fighter }, fighter);
        }

        // PUT: api/Ufcfighters/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUfcfighter(string id, Ufcfighter fighter)
        {
            if (id != fighter.Fighter)
                return BadRequest();

            _context.Entry(fighter).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Ufcfighters/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUfcfighter(string id)
        {
            var fighter = await _context.Ufcfighters.FindAsync(id);
            if (fighter == null)
                return NotFound();

            _context.Ufcfighters.Remove(fighter);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
