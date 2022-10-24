using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.models.dataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class indicesController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public indicesController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/indices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<index>>> Getindex()
        {
            return await _context.index.ToListAsync();
        }

        // GET: api/indices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<index>> Getindex(int id)
        {
            var index = await _context.index.FindAsync(id);

            if (index == null)
            {
                return NotFound();
            }

            return index;
        }

        // PUT: api/indices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putindex(int id, index index)
        {
            if (id != index.Id)
            {
                return BadRequest();
            }

            _context.Entry(index).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!indexExists(id))
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

        // POST: api/indices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<index>> Postindex(index index)
        {
            _context.index.Add(index);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getindex", new { id = index.Id }, index);
        }

        // DELETE: api/indices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteindex(int id)
        {
            var index = await _context.index.FindAsync(id);
            if (index == null)
            {
                return NotFound();
            }

            _context.index.Remove(index);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool indexExists(int id)
        {
            return _context.index.Any(e => e.Id == id);
        }
    }
}
