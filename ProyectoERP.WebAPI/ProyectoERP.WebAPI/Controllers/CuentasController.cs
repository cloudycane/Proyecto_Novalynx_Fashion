using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoERP.Dominio.Entidades;
using ProyectoERP.Infraestructura.DataAccess;

namespace ProyectoERP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CuentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cuentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuentaModel>>> GetCuentas()
        {
            return await _context.Cuentas.ToListAsync();
        }

        // GET: api/Cuentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CuentaModel>> GetCuentaModel(int id)
        {
            var cuentaModel = await _context.Cuentas.FindAsync(id);

            if (cuentaModel == null)
            {
                return NotFound();
            }

            return cuentaModel;
        }

        // PUT: api/Cuentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuentaModel(int id, CuentaModel cuentaModel)
        {
            if (id != cuentaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuentaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaModelExists(id))
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

        // POST: api/Cuentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CuentaModel>> PostCuentaModel(CuentaModel cuentaModel)
        {
            _context.Cuentas.Add(cuentaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuentaModel", new { id = cuentaModel.Id }, cuentaModel);
        }

        // DELETE: api/Cuentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuentaModel(int id)
        {
            var cuentaModel = await _context.Cuentas.FindAsync(id);
            if (cuentaModel == null)
            {
                return NotFound();
            }

            _context.Cuentas.Remove(cuentaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuentaModelExists(int id)
        {
            return _context.Cuentas.Any(e => e.Id == id);
        }
    }
}
