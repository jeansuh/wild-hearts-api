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
        public async Task<ActionResult<Response>> GetKemonos()
        {
            var response = new Response();
            if (_context.Kemonos == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Not Found";

            }

            response.StatusCode = 200;
            response.StatusDescription = "OK";
            response.KemonoDatas = await _context.Kemonos.ToListAsync(); ;
            
            return response;
        }


        // GET: api/Kemono/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetKemono(int id)
        {
            var response = new Response();

            if (_context.Kemonos == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Not Found";
            }
            var kemono = await _context.Kemonos.FindAsync(id);

            if (kemono == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Not Found";
            }

            if (id < 1 ^ id > 23)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request";
            }

            else
            {
                response.StatusCode = 200;
                response.StatusDescription = "OK";
                response.KemonoData = kemono;
            }

            return response;
        }

        // PUT: api/Kemono/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutKemono(int id, Kemono kemono)
        {
            var response = new Response();
            if (id != kemono.KemonoId)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request";
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
                    response.StatusCode = 404;
                    response.StatusDescription = "Not Found";
                }
                else
                {

                    throw;
                }
            }

            response.StatusCode = 201;
            response.StatusDescription = "Created";
            return response;
        }

        // POST: api/Kemono
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostKemono(Kemono kemono)
        {
            var response = new Response();
            if (_context.Kemonos == null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request: Entity set is null";
                //return Problem("Entity set 'WildHeartsAPIDBContext.Kemonos'  is null.");
            }
            else
            {
                _context.Kemonos.Add(kemono);
                await _context.SaveChangesAsync();

                response.StatusCode = 201;
                response.StatusDescription = "Created";
            }
            return response;

            //return CreatedAtAction("GetKemono", new { id = kemono.KemonoId }, kemono);
        }

        // DELETE: api/Kemono/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteKemono(int id)
        {
            var response = new Response();
            if (_context.Kemonos == null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request";
            }
            var kemono = await _context.Kemonos.FindAsync(id);
            if (kemono == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Not Found";
            }

            else
            {
                _context.Kemonos.Remove(kemono);
                await _context.SaveChangesAsync();
            }

            return response;
        }

        private bool KemonoExists(int id)
        {
            return (_context.Kemonos?.Any(e => e.KemonoId == id)).GetValueOrDefault();
        }
    }
}
