using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaFinal.Lib.DAL;
using PracticaFinal.Lib.Models.Relations;
using PracticaFinal.Web.Security;

namespace PracticaFinal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly PracticaFinalContext _context;

        public ReservasController(PracticaFinalContext context)
        {
            _context = context;
        }

        // GET: api/Reservas
        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            return await _context.Reservas.ToListAsync();
        }

        // GET: api/Reservas/ByMember
        [HttpGet("ByMember/{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservasByMember(Guid id)
        {
            return await _context.Reservas.Where(x => x.MemberId == id)
                .Include(b => b.Car).ToListAsync();
        }

        // GET: api/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(Guid id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        // PUT: api/Reservas/5
        [HttpPut]
        public async Task<IActionResult> PutReserva(Reserva reserva)
        {
            if (reserva.Id == default)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(reserva.Id))
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

        // POST: api/Reservas
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            // Esto lo hacemos para que el Reserva tenga inicializado el objeto Book
            reserva.Car = await _context.Cars.FindAsync(reserva.CarId);

            return CreatedAtAction("GetReserva", new { id = reserva.Id }, reserva);
        }

        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Reserva>> DeleteReserva(Guid id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return reserva;
        }

        private bool ReservaExists(Guid id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
