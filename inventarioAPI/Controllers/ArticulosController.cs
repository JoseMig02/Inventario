using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventarioAPI.Models;
using inventarioAPI.Data;

namespace inventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly InventarioContext _context;

        public ArticulosController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulos()
        {
            return await _context.Articulos.ToListAsync();
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        // POST: api/Articulos
        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.Id }, articulo);
        }

        // PUT: api/Articulos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(int id, Articulo articulo)
        {
            if (id != articulo.Id)
            {
                return BadRequest();
            }

            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
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

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.Id == id);
        }
    }
}
