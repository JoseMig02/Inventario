using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inventarioAPI.Models;
using inventarioAPI.Data;

namespace inventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        private readonly InventarioContext _context;

        public AlmacenController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/Almacen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Almacen>>> GetAlmacenes()
        {
            return await _context.Almacenes.ToListAsync();
        }

        // GET: api/Almacen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Almacen>> GetAlmacen(int id)
        {
            var almacen = await _context.Almacenes.FindAsync(id);

            if (almacen == null)
            {
                return NotFound();
            }

            return almacen;
        }

        // PUT: api/Almacen/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlmacen(int id, Almacen almacen)
        {
            if (id != almacen.Id)
            {
                return BadRequest();
            }

            _context.Entry(almacen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlmacenExists(id))
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

        // POST: api/Almacen
        [HttpPost]
        public async Task<ActionResult<Almacen>> PostAlmacen(Almacen almacen)
        {
            _context.Almacenes.Add(almacen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlmacen", new { id = almacen.Id }, almacen);
        }

        // DELETE: api/Almacen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlmacen(int id)
        {
            var almacen = await _context.Almacenes.FindAsync(id);
            if (almacen == null)
            {
                return NotFound();
            }

            _context.Almacenes.Remove(almacen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlmacenExists(int id)
        {
            return _context.Almacenes.Any(e => e.Id == id);
        }
    }
}
