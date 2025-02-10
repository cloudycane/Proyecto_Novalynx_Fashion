using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoERP.Dominio.Entidades;
using ProyectoERP.Infraestructura.DataAccess;

namespace ProyectoERP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaIngresoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriaIngresoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaIngreso
        [HttpGet]
        [EnableCors("AllowAngularApp")]
        public async Task<ActionResult<IEnumerable<CategoriaIngresoModel>>> GetCategoriasIngreso()
        {
            return await _context.CategoriasIngreso.ToListAsync();
        }

        // GET: api/CategoriaIngreso/5
        [HttpGet("{id}")]
        [EnableCors("AllowAngularApp")]
        public async Task<ActionResult<CategoriaIngresoModel>> GetCategoriaIngresoModel(int id)
        {
            var categoriaIngresoModel = await _context.CategoriasIngreso.FindAsync(id);

            if (categoriaIngresoModel == null)
            {
                return NotFound();
            }

            return categoriaIngresoModel;
        }

        // PUT: api/CategoriaIngreso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors("AllowAngularApp")]
        public async Task<IActionResult> PutCategoriaIngresoModel(int id, CategoriaIngresoModel categoriaIngresoModel)
        {
            if (id != categoriaIngresoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoriaIngresoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaIngresoModelExists(id))
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

        // POST: api/CategoriaIngreso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("AllowAngularApp")]
        public async Task<ActionResult<CategoriaIngresoModel>> PostCategoriaIngresoModel(CategoriaIngresoModel categoriaIngresoModel)
        {
            _context.CategoriasIngreso.Add(categoriaIngresoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaIngresoModel", new { id = categoriaIngresoModel.Id }, categoriaIngresoModel);
        }

        // DELETE: api/CategoriaIngreso/5
        [HttpDelete("{id}")]
        [EnableCors("AllowAngularApp")]
        public async Task<IActionResult> DeleteCategoriaIngresoModel(int id)
        {
            var categoriaIngresoModel = await _context.CategoriasIngreso.FindAsync(id);
            if (categoriaIngresoModel == null)
            {
                return NotFound();
            }

            _context.CategoriasIngreso.Remove(categoriaIngresoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaIngresoModelExists(int id)
        {
            return _context.CategoriasIngreso.Any(e => e.Id == id);
        }
    }
}
