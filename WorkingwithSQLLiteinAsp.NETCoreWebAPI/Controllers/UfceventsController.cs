using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkingwithSQLLiteinAsp.NETCoreWebAPI.Models;
using WorkingwithSQLLiteinAsp.NETCoreWebAPI.Data;

namespace WorkingwithSQLLiteinAsp.NETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UfceventsController : ControllerBase
    {
        private readonly MiDbContext _context;

        public UfceventsController(MiDbContext context)
        {
            _context = context;
        }

        // GET: api/Ufcevents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ufcevent>>> GetUfcevents()
        {
            return await _context.Ufcevents.ToListAsync();
        }

        // GET: api/Ufcevents/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Ufcevent>> GetUfcevent(string id)
        {
            var ufcevent = await _context.Ufcevents.FindAsync(id);
            if (ufcevent == null)
                return NotFound();

            return ufcevent;
        }

        // POST: api/Ufcevents
        [HttpPost]
        public async Task<ActionResult<Ufcevent>> PostUfcevent(Ufcevent ufcevent)
        {
            _context.Ufcevents.Add(ufcevent);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUfcevent), new { id = ufcevent.Event }, ufcevent);
        }

        // PUT: api/Ufcevents/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUfcevent(string id, Ufcevent ufcevent)
        {
            if (id != ufcevent.Event)
                return BadRequest();

            _context.Entry(ufcevent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Ufcevents/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUfcevent(string id)
        {
            var ufcevent = await _context.Ufcevents.FindAsync(id);
            if (ufcevent == null)
                return NotFound();

            _context.Ufcevents.Remove(ufcevent);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
