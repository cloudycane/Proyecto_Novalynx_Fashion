using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class PortalSuministradorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PortalSuministradorController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: PortalSuministradorController
        public async Task<IActionResult> Index()
        {
            var listadoSuministrador = await _context.Suministradores.ToListAsync();

            var viewModel = new ListadoPortalSuministradorViewModel()
            {
                listadoSuministrador = listadoSuministrador
            };
            return View(viewModel);
        }

        // GET: PortalSuministradorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PortalSuministradorController/Create
        public async Task<IActionResult> Crear()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null || user.Role != RoleEnum.Suministrador)
            {
                return Forbid();
            }
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(SuministradorModel model, IFormFile imagen)
        {
            var user = await _userManager.GetUserAsync(User);

            // Check if the user is authorized
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
                        return View(model);
                    }

                    // Validate file size (max 2 MB)
                    if (imagen.Length > 2 * 1024 * 1024) // 2 MB
                    {
                        ModelState.AddModelError("imagen", "La imagen debe tener como máximo 2 MB.");
                        return View(model);
                    }

                    // Set the directory path for saving the image
                    string folderPath = Path.Combine("wwwroot", "img", "imagen_suministrador");

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
                    model.RutaLogoImg = Path.Combine("img", "imagen_suministrador", fileName).Replace("\\", "/");
                }

                // Save the model to the database
                await _context.Suministradores.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }



        // POST: PortalSuministradorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null || user.Role != RoleEnum.Suministrador)
            {
                return Forbid();
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PortalSuministradorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PortalSuministradorController/Delete/5
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
