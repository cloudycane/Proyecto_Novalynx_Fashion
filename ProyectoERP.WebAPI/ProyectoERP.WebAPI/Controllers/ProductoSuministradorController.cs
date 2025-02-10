using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoERP.Dominio.Entidades;
using ProyectoERP.Infraestructura.DataAccess;

namespace ProyectoERP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoSuministradorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoSuministradorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductoSuministrador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoSuministradorModel>>> GetProductosSuministradores()
        {
            return await _context.ProductosSuministradores.ToListAsync();
        }

        // GET: api/ProductoSuministrador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoSuministradorModel>> GetProductoSuministradorModel(int id)
        {
            var productoSuministradorModel = await _context.ProductosSuministradores.FindAsync(id);

            if (productoSuministradorModel == null)
            {
                return NotFound();
            }

            return productoSuministradorModel;
        }

        // PUT: api/ProductoSuministrador/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoSuministradorModel(int id, ProductoSuministradorModel productoSuministradorModel)
        {
            if (id != productoSuministradorModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(productoSuministradorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoSuministradorModelExists(id))
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

        // POST: api/ProductoSuministrador
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductoSuministradorModel>> PostProductoSuministradorModel(ProductoSuministradorModel productoSuministradorModel)
        {
            _context.ProductosSuministradores.Add(productoSuministradorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductoSuministradorModel", new { id = productoSuministradorModel.Id }, productoSuministradorModel);
        }

        // DELETE: api/ProductoSuministrador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoSuministradorModel(int id)
        {
            var productoSuministradorModel = await _context.ProductosSuministradores.FindAsync(id);
            if (productoSuministradorModel == null)
            {
                return NotFound();
            }

            _context.ProductosSuministradores.Remove(productoSuministradorModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoSuministradorModelExists(int id)
        {
            return _context.ProductosSuministradores.Any(e => e.Id == id);
        }
    }
}
