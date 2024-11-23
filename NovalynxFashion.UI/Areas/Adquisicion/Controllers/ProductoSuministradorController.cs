using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovalynxFashion.Core.Entidades;
using NovalynxFashion.Core.Entidades.IdentityEntities;
using NovalynxFashion.Core.Enums;
using NovalynxFashion.Infrastructure.Data;
using NovalynxFashion.UI.ViewModels;

namespace NovalynxFashion.UI.Areas.Adquisicion.Controllers
{
    [Area("Adquisicion")]
    [Authorize]
    public class ProductoSuministradorController : Controller
    {
        private readonly ApplicationDbContext _context; 
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductoSuministradorController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: ProductoSuministradorController
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null || user.Role == RoleEnum.Cliente || user.Role == RoleEnum.RecursoHumano || user.Role == RoleEnum.Marketing)
            {
                return Forbid();
            }

            var listadoProducto = await _context.ProductoSuministradores.Include(s => s.Suministrador).ToListAsync();

            var viewModel = new ListadoProductoSuministradorViewModel
            {
                ListadoProductoSuministrador = listadoProducto
            };

            return View(viewModel);
        }

        // GET: ProductoSuministradorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoSuministradorController/Create
        public async Task<IActionResult> Crear()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null || user.Role != RoleEnum.Suministrador)
            {
                return Forbid();
            }

            var listadoSuministrador = await _context.Suministradores.ToListAsync();
            ViewBag.SuministradorSelectList = new SelectList(listadoSuministrador, "Id", "NombreSuministrador");
            var model = new ProductoSuministradorModel();
            return View(model);
        }


        // POST: ProductoSuministradorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(ProductoSuministradorModel productoSuministrador, IFormFile imagen)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null || user.Role != RoleEnum.Suministrador)
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                // Handle file upload
                if (imagen != null && imagen.Length > 0)
                {
                    // Validate file type (only accept jpeg or png)
                    var allowedTypes = new[] { "image/jpeg", "image/png" };
                    if (!allowedTypes.Contains(imagen.ContentType))
                    {
                        ModelState.AddModelError("imagen", "Debe subir una imagen en formato jpeg o png.");
                        return View(productoSuministrador);
                    }

                    // Validate file size (max 2 MB)
                    if (imagen.Length > 2 * 1024 * 1024) // 2 MB
                    {
                        ModelState.AddModelError("imagen", "La imagen debe tener como máximo 2 MB.");
                        return View(productoSuministrador);
                    }

                    // Set the directory path for saving the image
                    string folderPath = Path.Combine("wwwroot", "img", "imagen_productoSuministrador");

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
                    productoSuministrador.ImagePath = Path.Combine("img", "imagen_productoSuministrador", fileName).Replace("\\", "/");
                }
                await _context.ProductoSuministradores.AddAsync(productoSuministrador); 
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productoSuministrador);
        }

        // GET: ProductoSuministradorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoSuministradorController/Edit/5
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

        // GET: ProductoSuministradorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoSuministradorController/Delete/5
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
