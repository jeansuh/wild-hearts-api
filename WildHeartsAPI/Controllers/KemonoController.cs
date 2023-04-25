using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WildHeartsAPI.Models;

namespace WildHeartsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class KemonoController : ControllerBase
    {
        private readonly WildHeartsAPIDBContext _context;

        public KemonoController(WildHeartsAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Kemono
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kemono>>> GetKemonos()
        {
            if (_context.Kemonos == null)
            {
                return NotFound();
            }
            return await _context.Kemonos.ToListAsync();
        }


        // GET: api/Kemono/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kemono>> GetKemono(int id)
        {
          if (_context.Kemonos == null)
          {
              return NotFound();
          }
            var kemono = await _context.Kemonos.FindAsync(id);

            if (kemono == null)
            {
                return NotFound();
            }

            return kemono;
        }

        // PUT: api/Kemono/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKemono(int id, Kemono kemono)
        {
            if (id != kemono.KemonoId)
            {
                return BadRequest();
            }

            _context.Entry(kemono).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KemonoExists(id))
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

        // POST: api/Kemono
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kemono>> PostKemono(Kemono kemono)
        {
          if (_context.Kemonos == null)
          {
              return Problem("Entity set 'WildHeartsAPIDBContext.Kemonos'  is null.");
          }
            _context.Kemonos.Add(kemono);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKemono", new { id = kemono.KemonoId }, kemono);
        }

        // DELETE: api/Kemono/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKemono(int id)
        {
            if (_context.Kemonos == null)
            {
                return NotFound();
            }
            var kemono = await _context.Kemonos.FindAsync(id);
            if (kemono == null)
            {
                return NotFound();
            }

            _context.Kemonos.Remove(kemono);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KemonoExists(int id)
        {
            return (_context.Kemonos?.Any(e => e.KemonoId == id)).GetValueOrDefault();
        }
    }
}
