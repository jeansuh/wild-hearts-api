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
    public class MaterialController : ControllerBase
    {
        private readonly WildHeartsAPIDBContext _context;

        public MaterialController(WildHeartsAPIDBContext context)
        {
            _context = context;
        }

        //[HttpGet("{chapter}")]
        //public ActionResult<IEnumerable<Material>> MaterialByKemonoId(int Chapter)
        //{
        //    _context.
        //}

        //GET: api/Material

       [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterials()
        {
          if (_context.Materials == null)
          {
              return NotFound();
          }
            return await _context.Materials.ToListAsync();
        }

        // GET: api/Material/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
          if (_context.Materials == null)
          {
              return NotFound();
          }
            var material = await _context.Materials.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        // PUT: api/Material/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, Material material)
        {
            if (id != material.MaterialId)
            {
                return BadRequest();
            }

            _context.Entry(material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
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

        // POST: api/Material
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(Material material)
        {
          if (_context.Materials == null)
          {
              return Problem("Entity set 'WildHeartsAPIDBContext.Materials'  is null.");
          }
            _context.Materials.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = material.MaterialId }, material);
        }

        // DELETE: api/Material/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            if (_context.Materials == null)
            {
                return NotFound();
            }
            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialExists(int id)
        {
            return (_context.Materials?.Any(e => e.MaterialId == id)).GetValueOrDefault();
        }
    }
}
