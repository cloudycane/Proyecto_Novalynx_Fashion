
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovalynxFashion.Core.Entidades;
using NovalynxFashion.Core.Entidades.IdentityEntities;
using NovalynxFashion.Core.Enums;
using NovalynxFashion.Infrastructure.Data;
using NovalynxFashion.UI.ViewModels;

namespace AgriTechERP.Web.Areas.Adquisicion.Controllers
{
    [Area("Adquisicion")]
    [Authorize]
    public class OrdenCarritoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public OrdenCarritoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;        
        }
        // GET: OrdenCarritoController
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null || user.Role == RoleEnum.Cliente || user.Role == RoleEnum.Ventas || user.Role == RoleEnum.RecursoHumano ||  user.Role == RoleEnum.Marketing)
            {
                return Forbid();
            }


            var ordenes = await _context.OrdenesEnCarrito.Include(p => p.ProductoSuministrador).ToListAsync();

            var viewModel = new ListadoOrdenCarritoViewModel
            {
                OrdenesEnCarrito = ordenes
            };
            return View(viewModel);
        }

        // GET: OrdenCarritoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ordenar(int productoId, int cantidad)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null || user.Role != RoleEnum.Empleado)
            {
                return Forbid();
            }

            var producto = await _context.ProductoSuministradores.FindAsync(productoId);

            if (producto == null)
            {
                return NotFound();
            }

            var carritoItem = await _context.OrdenesEnCarrito.SingleOrDefaultAsync(c => c.ProductoSuministradorId == productoId);

            if (carritoItem != null && carritoItem.ProductoSuministrador != null)
            {
                carritoItem.Cantidad += cantidad; 
            }
            else
            {
                carritoItem = new OrdenesEnCarritoModel()
                {
                    ProductoSuministradorId = productoId,
                    Aprobacion = 0,
                    Cantidad = cantidad 
                };

                await _context.OrdenesEnCarrito.AddAsync(carritoItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: OrdenCarritoController/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: OrdenCarritoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenCarritoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenCarritoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenCarritoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenCarritoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}