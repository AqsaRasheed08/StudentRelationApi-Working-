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
    public class TechesController : ControllerBase
    {
        private readonly StudentRelationContext _context;

        public TechesController(StudentRelationContext context)
        {
            _context = context;
        }

        // GET: api/Teches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tech>>> GetTeches()
        {
            return await _context.Teches.ToListAsync();
        }

        // GET: api/Teches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tech>> GetTech(int id)
        {
            var tech = await _context.Teches.FindAsync(id);

            if (tech == null)
            {
                return NotFound();
            }

            return tech;
        }

        // PUT: api/Teches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTech(int id, Tech tech)
        {
            if (id != tech.TeacherId)
            {
                return BadRequest();
            }

            _context.Entry(tech).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechExists(id))
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

        // POST: api/Teches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tech>> PostTech(Tech tech)
        {
            _context.Teches.Add(tech);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TechExists(tech.TeacherId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTech", new { id = tech.TeacherId }, tech);
        }

        // DELETE: api/Teches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTech(int id)
        {
            var tech = await _context.Teches.FindAsync(id);
            if (tech == null)
            {
                return NotFound();
            }

            _context.Teches.Remove(tech);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TechExists(int id)
        {
            return _context.Teches.Any(e => e.TeacherId == id);
        }
    }
}
