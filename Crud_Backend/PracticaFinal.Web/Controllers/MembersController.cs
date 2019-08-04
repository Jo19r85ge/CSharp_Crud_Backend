using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaFinal.Lib.DAL;
using PracticaFinal.Lib.Models;
using PracticaFinal.Web.Security;

namespace PracticaFinal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly PracticaFinalContext _context;

        public MembersController(PracticaFinalContext context)
        {
            _context = context;
        }

        // GET: api/Members
        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(Guid id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // PUT: api/Members/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(Guid id, Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/Members
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.Id }, member);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Member>> DeleteMember(Guid id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return member;
        }

        private bool MemberExists(Guid id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
