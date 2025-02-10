using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoERP.Dominio.Entidades;
using ProyectoERP.Infraestructura.DataAccess;

namespace ProyectoERP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaGastoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriaGastoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaGasto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaGastoModel>>> GetCategoriasGasto()
        {
            return await _context.CategoriasGasto.ToListAsync();
        }

        // GET: api/CategoriaGasto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaGastoModel>> GetCategoriaGastoModel(int id)
        {
            var categoriaGastoModel = await _context.CategoriasGasto.FindAsync(id);

            if (categoriaGastoModel == null)
            {
                return NotFound();
            }

            return categoriaGastoModel;
        }

        // PUT: api/CategoriaGasto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaGastoModel(int id, CategoriaGastoModel categoriaGastoModel)
        {
            if (id != categoriaGastoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoriaGastoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaGastoModelExists(id))
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

        // POST: api/CategoriaGasto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaGastoModel>> PostCategoriaGastoModel(CategoriaGastoModel categoriaGastoModel)
        {
            _context.CategoriasGasto.Add(categoriaGastoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaGastoModel", new { id = categoriaGastoModel.Id }, categoriaGastoModel);
        }

        // DELETE: api/CategoriaGasto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaGastoModel(int id)
        {
            var categoriaGastoModel = await _context.CategoriasGasto.FindAsync(id);
            if (categoriaGastoModel == null)
            {
                return NotFound();
            }

            _context.CategoriasGasto.Remove(categoriaGastoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaGastoModelExists(int id)
        {
            return _context.CategoriasGasto.Any(e => e.Id == id);
        }
    }
}
