using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovalynxFashion.Core.Entidades;
using NovalynxFashion.Core.Entidades.IdentityEntities;
using NovalynxFashion.Core.Enums;
using NovalynxFashion.Infrastructure.Data;
using static System.Net.Mime.MediaTypeNames;

namespace NovalynxFashion.UI.Areas.Inventario.Controllers
{
    [Area("Inventario")]
    public class ProduccionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProduccionController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Produccion/Index
        public async Task<IActionResult> Index()
        {

            var producciones = await _context.ProductosEnVentas
                .Include(p => p.Ingredientes) // Cargar los ingredientes
                .ToListAsync();

            return View(producciones);
        }

        // GET: Produccion/Crear
        public async Task<IActionResult> Crear()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user.Role == null || user.Role != RoleEnum.Empleado)
            {
                return Forbid();
            }
            var productosSuministradores = await _context.ProductoSuministradores.ToListAsync();
            ViewBag.ProductosSuministradores = productosSuministradores;
            return View(new ProductosEnProduccionModel());
        }

        // POST: Produccion/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(ProductosEnProduccionModel produccionModel, int[] ingredientesIds, IFormFile imagen)
        {
            if (ModelState.IsValid)
            {
                foreach (var ingredienteId in ingredientesIds)
                {
                    var productoSuministrador = await _context.ProductoSuministradores.FindAsync(ingredienteId);
                    if (productoSuministrador != null)
                    {
                        produccionModel.Ingredientes.Add(productoSuministrador);
                    }
                }

                // Handle file upload
                if (imagen != null && imagen.Length > 0)
                {
                    // Validate file type (only accept jpeg or png)
                    var allowedTypes = new[] { "image/jpeg", "image/png" };
                    if (!allowedTypes.Contains(imagen.ContentType))
                    {
                        ModelState.AddModelError("imagen", "Debe subir una imagen en formato jpeg o png.");
                        return View(produccionModel);
                    }

                    // Validate file size (max 2 MB)
                    if (imagen.Length > 2 * 1024 * 1024) // 2 MB
                    {
                        ModelState.AddModelError("imagen", "La imagen debe tener como máximo 2 MB.");
                        return View(produccionModel);
                    }

                    // Set the directory path for saving the image
                    string folderPath = Path.Combine("wwwroot", "img", "imagen_productoVender");

                    // Create the directory if it doesn't exist
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Create a unique file name
                    string fileName = $"{Guid.NewGuid()}_{Path.GetFileName(imagen.FileName)}";
                    string filePath = Path.Combine(folderPath, fileName);

                    // Save the file to the specified path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imagen.CopyToAsync(stream);
                    }

                    // Save the relative file path in the model's property
                    produccionModel.ImagePath = Path.Combine("img", "imagen_productoVender", fileName).Replace("\\", "/");
                }





                _context.ProductosEnVentas.Add(produccionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ProductosSuministradores = await _context.ProductoSuministradores.ToListAsync();
            return View(produccionModel);
        }
    }
}
