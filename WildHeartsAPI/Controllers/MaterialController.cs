using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
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

        //GET: api/Material
        [HttpGet]
        public async Task<ActionResult<Models.Response>> GetMaterials()
        {
            var response = new Models.Response();
            if (_context.Materials == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Not Found";

            }
            else
            {
                response.StatusCode = 200;
                response.StatusDescription = "OK";
                response.MaterialDatas = await _context.Materials.ToListAsync();
            }

            return response;
        }


        // GET: api/Material/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Response>> GetMaterial(int id)
        {
            var response = new Models.Response();

            if (_context.Materials == null)
                {
                    response.StatusCode = 404;
                    response.StatusDescription = "Not Found";
                }
            var material = await _context.Materials.FindAsync(id);

            if (material == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Not Found";
            }

            if (id < 1 ^ id > 179)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request";
            }

            else
            {
                response.StatusCode = 200;
                response.StatusDescription = "OK";
                response.MaterialData = material;
            }

            return response;
        }

        // PUT: api/Material/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Models.Response>> PutMaterial(int id, Material material)
        {
            var response = new Models.Response();

            if (id != material.MaterialId)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request";
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

        // POST: api/Material
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.Response>> PostMaterial(Material material)
        {
            var response = new Models.Response();
            if (_context.Materials == null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request: Entity set is null";
            }
            else
            {
                _context.Materials.Add(material);
                await _context.SaveChangesAsync();

                response.StatusCode = 201;
                response.StatusDescription = "Created";
            }
            return response;
        }

        // DELETE: api/Material/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Response>> DeleteMaterial(int id)
        {
            var response = new Models.Response();
            if (_context.Materials == null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request: Entity set is null";
            }
            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Not Found";
            }

            else
            {
                _context.Materials.Remove(material);
                await _context.SaveChangesAsync();
            }

            return response;
        }

        private bool MaterialExists(int id)
        {
            return (_context.Materials?.Any(e => e.MaterialId == id)).GetValueOrDefault();
        }
    }
}
