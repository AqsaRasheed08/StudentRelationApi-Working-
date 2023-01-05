using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRelationApi.Models;

namespace StudentRelationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudsController : ControllerBase
    {
        private readonly StudentRelationContext _context;

        public StudsController(StudentRelationContext context)
        {
            _context = context;
        }

        // GET: api/Stud
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stud>>> GetStud()
        {
            return await _context.Stud.ToListAsync();
        }

        // GET: api/Stud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stud>> GetStud(int id)
        {
            var stud = await _context.Stud.FindAsync(id);

            if (stud == null)
            {
                return NotFound();
            }

            return stud;
        }

        // PUT: api/Studs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStud(int id, Stud stud)
        {
            if (id != stud.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(stud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudExists(id))
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

        // POST: api/Studs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stud>> PostStud(Stud stud)
        {
            _context.Stud.Add(stud);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudExists(stud.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStud", new { id = stud.StudentId }, stud);
        }

        // DELETE: api/Studs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStud(int id)
        {
            var stud = await _context.Stud.FindAsync(id);
            if (stud == null)
            {
                return NotFound();
            }

            _context.Stud.Remove(stud);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudExists(int id)
        {
            return _context.Stud.Any(e => e.StudentId == id);
        }
    }
}
