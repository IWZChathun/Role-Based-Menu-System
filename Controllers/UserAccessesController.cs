using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RBMS;
using RBMS.Entities;

namespace RBMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccessesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserAccessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserAccesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccess>>> GetUserAccesses()
        {
            return await _context.UserAccesses.ToListAsync();
        }

        // GET: api/UserAccesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccess>> GetUserAccess(long id)
        {
            var userAccess = await _context.UserAccesses.FindAsync(id);

            if (userAccess == null)
            {
                return NotFound();
            }

            return userAccess;
        }

        // PUT: api/UserAccesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAccess(long id, UserAccess userAccess)
        {
            if (id != userAccess.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccessExists(id))
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

        // POST: api/UserAccesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserAccess>> PostUserAccess(UserAccess userAccess)
        {
            _context.UserAccesses.Add(userAccess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAccess", new { id = userAccess.Id }, userAccess);
        }

        // DELETE: api/UserAccesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccess(long id)
        {
            var userAccess = await _context.UserAccesses.FindAsync(id);
            if (userAccess == null)
            {
                return NotFound();
            }

            _context.UserAccesses.Remove(userAccess);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAccessExists(long id)
        {
            return _context.UserAccesses.Any(e => e.Id == id);
        }
    }
}
