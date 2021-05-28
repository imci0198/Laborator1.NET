using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laborator1.NET.Data;
using Laborator1.NET.Models;

namespace Laborator1.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacistsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PharmacistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pharmacists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pharmacists>>> GetPharmacists()
        {
            return await _context.Pharmacists.ToListAsync();
        }

        // GET: api/Pharmacists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pharmacists>> GetPharmacists(int id)
        {
            var pharmacists = await _context.Pharmacists.FindAsync(id);

            if (pharmacists == null)
            {
                return NotFound();
            }

            return pharmacists;
        }

        // PUT: api/Pharmacists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacists(int id, Pharmacists pharmacists)
        {
            if (id != pharmacists.id)
            {
                return BadRequest();
            }

            _context.Entry(pharmacists).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacistsExists(id))
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

        // POST: api/Pharmacists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pharmacists>> PostPharmacists(Pharmacists pharmacists)
        {
            _context.Pharmacists.Add(pharmacists);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPharmacists", new { id = pharmacists.id }, pharmacists);
        }

        // DELETE: api/Pharmacists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacists(int id)
        {
            var pharmacists = await _context.Pharmacists.FindAsync(id);
            if (pharmacists == null)
            {
                return NotFound();
            }

            _context.Pharmacists.Remove(pharmacists);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PharmacistsExists(int id)
        {
            return _context.Pharmacists.Any(e => e.id == id);
        }
    }
}
