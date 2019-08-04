using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaFinal.Lib.DAL;
using PracticaFinal.Lib.Models;

namespace PracticaFinal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurgoesController : ControllerBase
    {
        private readonly PracticaFinalContext _context;

        public FurgoesController(PracticaFinalContext context)
        {
            _context = context;
        }

        // GET: api/Furgoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Furgo>>> GetFurgos()
        {
            return await _context.Furgos.ToListAsync();
        }

        // GET: api/Furgoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Furgo>> GetFurgo(Guid id)
        {
            var furgo = await _context.Furgos.FindAsync(id);

            if (furgo == null)
            {
                return NotFound();
            }

            return furgo;
        }

        // PUT: api/Furgoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFurgo(Guid id, Furgo furgo)
        {
            if (id != furgo.Id)
            {
                return BadRequest();
            }

            _context.Entry(furgo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FurgoExists(id))
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

        // POST: api/Furgoes
        [HttpPost]
        public async Task<ActionResult<Furgo>> PostFurgo(Furgo furgo)
        {
            _context.Furgos.Add(furgo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFurgo", new { id = furgo.Id }, furgo);
        }

        // DELETE: api/Furgoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Furgo>> DeleteFurgo(Guid id)
        {
            var furgo = await _context.Furgos.FindAsync(id);
            if (furgo == null)
            {
                return NotFound();
            }

            _context.Furgos.Remove(furgo);
            await _context.SaveChangesAsync();

            return furgo;
        }

        private bool FurgoExists(Guid id)
        {
            return _context.Furgos.Any(e => e.Id == id);
        }
    }
}
