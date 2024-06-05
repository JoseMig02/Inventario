using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inventarioAPI.Data;
using inventarioAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoInventarioController : ControllerBase
    {
        private readonly InventarioContext _context;

        public TipoInventarioController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/TipoInventario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoInventario>>> GetTipoInventarios()
        {
            return await _context.TiposInventario.ToListAsync();
        }

        // GET: api/TipoInventario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoInventario>> GetTipoInventario(int id)
        {
            var tipoInventario = await _context.TiposInventario.FindAsync(id);

            if (tipoInventario == null)
            {
                return NotFound();
            }

            return tipoInventario;
        }

        // PUT: api/TipoInventario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoInventario(int id, TipoInventario tipoInventario)
        {
            if (id != tipoInventario.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoInventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoInventarioExists(id))
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

        // POST: api/TipoInventario
        [HttpPost]
        public async Task<ActionResult<TipoInventario>> PostTipoInventario(TipoInventario tipoInventario)
        {
            _context.TiposInventario.Add(tipoInventario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoInventario", new { id = tipoInventario.Id }, tipoInventario);
        }

        // DELETE: api/TipoInventario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoInventario(int id)
        {
            var tipoInventario = await _context.TiposInventario.FindAsync(id);
            if (tipoInventario == null)
            {
                return NotFound();
            }

            _context.TiposInventario.Remove(tipoInventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoInventarioExists(int id)
        {
            return _context.TiposInventario.Any(e => e.Id == id);
        }
    }
}
