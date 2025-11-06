using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkingwithSQLLiteinAsp.NETCoreWebAPI.Models;
using WorkingwithSQLLiteinAsp.NETCoreWebAPI.Data;

namespace WorkingwithSQLLiteinAsp.NETCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UfcresultsController : ControllerBase
    {
        private readonly MiDbContext _context;

        public UfcresultsController(MiDbContext context)
        {
            _context = context;
        }

        // GET: api/Ufcresults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ufcresult>>> GetUfcresults()
        {
            return await _context.Ufcresults.ToListAsync();
        }

        // GET: api/Ufcresults/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Ufcresult>> GetUfcresult(string id)
        {
            var result = await _context.Ufcresults.FindAsync(id);
            if (result == null)
                return NotFound();

            return result;
        }

        // POST: api/Ufcresults
        [HttpPost]
        public async Task<ActionResult<Ufcresult>> PostUfcresult(Ufcresult result)
        {
            _context.Ufcresults.Add(result);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUfcresult), new { id = result.Fighters }, result);
        }

        // PUT: api/Ufcresults/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUfcresult(string id, Ufcresult result)
        {
            if (id != result.Fighters)
                return BadRequest();

            _context.Entry(result).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Ufcresults/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUfcresult(string id)
        {
            var result = await _context.Ufcresults.FindAsync(id);
            if (result == null)
                return NotFound();

            _context.Ufcresults.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
