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
    public class SuministradorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SuministradorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Suministrador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuministradorModel>>> GetSuministradores()
        {
            return await _context.Suministradores.ToListAsync();
        }

        // GET: api/Suministrador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuministradorModel>> GetSuministradorModel(int id)
        {
            var suministradorModel = await _context.Suministradores.FindAsync(id);

            if (suministradorModel == null)
            {
                return NotFound();
            }

            return suministradorModel;
        }

        // PUT: api/Suministrador/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuministradorModel(int id, SuministradorModel suministradorModel)
        {
            if (id != suministradorModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(suministradorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuministradorModelExists(id))
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

        // POST: api/Suministrador
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SuministradorModel>> PostSuministradorModel(SuministradorModel suministradorModel)
        {
            _context.Suministradores.Add(suministradorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuministradorModel", new { id = suministradorModel.Id }, suministradorModel);
        }

        // DELETE: api/Suministrador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuministradorModel(int id)
        {
            var suministradorModel = await _context.Suministradores.FindAsync(id);
            if (suministradorModel == null)
            {
                return NotFound();
            }

            _context.Suministradores.Remove(suministradorModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuministradorModelExists(int id)
        {
            return _context.Suministradores.Any(e => e.Id == id);
        }
    }
}
