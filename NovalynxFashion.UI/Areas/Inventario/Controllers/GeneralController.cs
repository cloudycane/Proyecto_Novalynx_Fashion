using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovalynxFashion.Core.Entidades.IdentityEntities;
using NovalynxFashion.Core.Enums;
using NovalynxFashion.Infrastructure.Data;
using NovalynxFashion.UI.ViewModels;

namespace NovalynxFashion.UI.Areas.Inventario.Controllers
{
    [Area("Inventario")]
    public class GeneralController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public GeneralController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: InventarioController
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user.Role == null || user.Role != RoleEnum.Empleado)
            {
                return Forbid();
            }
            var listadoInventario = await _context.Inventarios.Include(p => p.ProductoSuministrador).ToListAsync();

            var viewModel = new ListadoInventarioViewModel
            {
                Inventario = listadoInventario
            };
            return View(viewModel);
        }

        // GET: InventarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> AñadirAlInventario(int ordenId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user.Role == null || user.Role != RoleEnum.Empleado)
            {
                return Forbid();
            }

            var orden = await _context.OrdenesEnCarrito.Include(o => o.ProductoSuministrador).SingleOrDefaultAsync(o => o.Id == ordenId);

            if (orden == null)
            {
                return NotFound();
            }

            var inventarioItem = await _context.Inventarios.SingleOrDefaultAsync(p => p.ProductoSuministradorId == orden.ProductoSuministrador.Id);

            if (inventarioItem != null)
            {
                inventarioItem.StockActual += orden.Cantidad;

            }
            else
            {
                inventarioItem = new Core.Entidades.InventarioModel
                {
                    ProductoSuministradorId = orden.ProductoSuministrador.Id,
                    StockActual = orden.Cantidad,
                    OrdenCarritoId = orden.Id,

                };

                await _context.Inventarios.AddAsync(inventarioItem);
            }

            _context.OrdenesEnCarrito.Remove(orden);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "General", new { area = "Inventario" });

        }

        // GET: InventarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: InventarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventarioController/Edit/5
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

        // GET: InventarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventarioController/Delete/5
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
