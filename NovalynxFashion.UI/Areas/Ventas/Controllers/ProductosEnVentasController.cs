using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovalynxFashion.Core.Entidades;
using NovalynxFashion.Core.Entidades.IdentityEntities;
using NovalynxFashion.Core.Enums;
using NovalynxFashion.Infrastructure.Data;
using NovalynxFashion.UI.ViewModels;

namespace NovalynxFashion.UI.Areas.Ventas.Controllers
{
    [Area("Ventas")]
    [Authorize]
    public class ProductosEnVentasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductosEnVentasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();

            var viewModel = new ListadoProductosEnVentaViewModel()
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Vender(int productoEnProduccionId)
        {
            var producto = await _context.ProductosEnVentas
                             .Where(p => p.Id == productoEnProduccionId)
                             .FirstOrDefaultAsync();

            if (producto == null)
            {
                // Log or use breakpoint here
                return NotFound();
            }

            var productoParaVender = await _context.ProductosParaLaVenta
                .SingleOrDefaultAsync(p => p.ProductosEnProduccionModelId == productoEnProduccionId);

            if (productoParaVender == null)
            {
                productoParaVender = new ProductosParaLaVentaModel()
                {
                    ProductosEnProduccionModelId = productoEnProduccionId,
                };

                await _context.ProductosParaLaVenta.AddAsync(productoParaVender);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> OrdenarPorAccesorios()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
               ListadoProductosParaLaVenta = listadoProductoEnVentas
            };
            
            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorAccesoriosAlfabeticamenteCreciente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorAccesoriosAlfabeticamenteDescendente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorAccesoriosPrecioMayorAMenor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorAccesoriosPrecioMenorAMayor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorCalzados()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorCalzadosAlfabeticamenteCreciente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorCalzadosAlfabeticamenteDescendente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorCalzadosPrecioMayorAMenor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorCalzadosPrecioMenorAMayor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaCasual()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaCasualAlfabeticamenteCreciente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaCasualAlfabeticamenteDescendente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaCasualPrecioMayorAMenor(){
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaCasualPrecioMenorAMayor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaDeportivo()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaDeportivoAlfabeticamenteCreciente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaDeportivoAlfabeticamenteDescendente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaDeportivoPrecioMenorAMayor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaDeportivoPrecioMayorAMenor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaInterior()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaInteriorAlfabeticamenteCreciente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }


        public async Task<IActionResult> OrdenarPorRopaInteriorAlfabeticamenteDescendente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }


        public async Task<IActionResult> OrdenarPorRopaInteriorPrecioMayorAMenor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaInteriorPrecioMenorAMayor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaFormal()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaFormalAlfabeticamenteCreciente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaFormalAlfabeticamenteDescendente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaFormalPrecioMayorAMenor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }


        public async Task<IActionResult> OrdenarPorRopaFormalPrecioMenorAMayor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }


        public async Task<IActionResult> OrdenarPorRopaOficina()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }


        public async Task<IActionResult> OrdenarPorRopaOficinaAlfabeticamenteCreciente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }


        public async Task<IActionResult> OrdenarPorRopaOficinaAlfabeticamenteDescendente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }


        public async Task<IActionResult> OrdenarPorRopaOficinaPrecioMayorAMenor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaOficinaPrecioMenorAMayor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaInvierno()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaInviernoAlfabeticamenteCreciente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaInviernoAlfabeticamenteDescendente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaInviernoPrecioMayorAMenor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaInviernoPrecioMenorAMayor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaVerano()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaVeranoAlfabeticamenteCreciente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaVeranoAlfabeticamenteDescendente()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaVeranoPrecioMayorAMenor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }

        public async Task<IActionResult> OrdenarPorRopaVeranoPrecioMenorAMayor()
        {
            var listadoProductoEnVentas = await _context.ProductosParaLaVenta.Include(p => p.ProductosTerminados).ToListAsync();


            var viewModel = new ListadoProductosEnVentaViewModel
            {
                ListadoProductosParaLaVenta = listadoProductoEnVentas
            };

            return View(viewModel);
        }
    }
}
