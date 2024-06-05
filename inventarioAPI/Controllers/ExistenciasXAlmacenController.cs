using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inventarioAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventarioAPI.Data;

namespace inventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExistenciasXAlmacenController : ControllerBase
    {
        private readonly InventarioContext _context;

        public ExistenciasXAlmacenController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/ExistenciasXAlmacen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExistenciasXAlmacen>>> GetExistenciasXAlmacen()
        {
            return await _context.ExistenciasXAlmacenes.ToListAsync();
        }

        // GET: api/ExistenciasXAlmacen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExistenciasXAlmacen>> GetExistenciasXAlmacen(int id)
        {
            var existenciasXAlmacen = await _context.ExistenciasXAlmacenes.FindAsync(id);

            if (existenciasXAlmacen == null)
            {
                return NotFound();
            }

            return existenciasXAlmacen;
        }

        // PUT: api/ExistenciasXAlmacen/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExistenciasXAlmacen(int id, ExistenciasXAlmacen existenciasXAlmacen)
        {
            if (id != existenciasXAlmacen.Id)
            {
                return BadRequest();
            }

            _context.Entry(existenciasXAlmacen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExistenciasXAlmacenExists(id))
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

        // POST: api/ExistenciasXAlmacen
        [HttpPost]
        public async Task<ActionResult<ExistenciasXAlmacen>> PostExistenciasXAlmacen(ExistenciasXAlmacen existenciasXAlmacen)
        {
            _context.ExistenciasXAlmacenes.Add(existenciasXAlmacen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExistenciasXAlmacen", new { id = existenciasXAlmacen.Id }, existenciasXAlmacen);
        }

        // DELETE: api/ExistenciasXAlmacen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExistenciasXAlmacen(int id)
        {
            var existenciasXAlmacen = await _context.ExistenciasXAlmacenes.FindAsync(id);
            if (existenciasXAlmacen == null)
            {
                return NotFound();
            }

            _context.ExistenciasXAlmacenes.Remove(existenciasXAlmacen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExistenciasXAlmacenExists(int id)
        {
            return _context.ExistenciasXAlmacenes.Any(e => e.Id == id);
        }
    }
}
