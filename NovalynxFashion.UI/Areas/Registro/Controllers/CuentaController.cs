

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NovalynxFashion.Core.Entidades.DTO;
using NovalynxFashion.Core.Entidades.IdentityEntities;
using NovalynxFashion.Core.Enums;
using NovalynxFashion.Infrastructure.Data;

namespace AgriTechERP.Web.Areas.Registrar.Controllers
{
    [Area("Registro")]
    [AllowAnonymous]
    public class CuentaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public CuentaController(ApplicationDbContext context,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // GET: CuentaController
       
        public async Task<IActionResult> Index()
        {
            var productosPendienteDeAprobación = _context.OrdenesEnCarrito.Where(estado => estado.Aprobacion == AprobacionEnum.PendienteDeAprobacion).ToList();
            var productosEnProduccionEnRevision = _context.ProductosEnVentas.Where(estado => estado.EstadoProducto == EstadoProductoEnProduccionEnum.EnRevision);
            var elementosEnElInventarioQueFaltanStock = _context.Inventarios.Where(stock => stock.StockActual < 20);
            ViewBag.NumeroDeProductosPendiente = productosPendienteDeAprobación.Count();
            ViewBag.NumeroDeProductosEnRevision = productosEnProduccionEnRevision.Count();
            ViewBag.ElementosEnElInventarioQueFaltanStock = elementosEnElInventarioQueFaltanStock.Count();
            
            return View();
        }
        
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarDTO registrarDTO, IFormFile imagen)
        {
           
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values
                                           .SelectMany(temp => temp.Errors)
                                           .Select(temp => temp.ErrorMessage);
                return View(registrarDTO);
            }

            if (imagen != null && imagen.Length > 0)
            {
             
                var allowedTypes = new[] { "image/jpeg", "image/png" };
                if (!allowedTypes.Contains(imagen.ContentType))
                {
                    ModelState.AddModelError("imagen", "Debe subir una imagen en formato jpeg o png.");
                    return View(registrarDTO);
                }

                // Validate file size (max 2 MB)
                if (imagen.Length > 2 * 1024 * 1024) // 2 MB
                {
                    ModelState.AddModelError("imagen", "La imagen debe tener como máximo 2 MB.");
                    return View(registrarDTO);
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
                registrarDTO.ImageProfile = Path.Combine("img", "imagen_productoSuministrador", fileName).Replace("\\", "/");
            }

            // Initialize ApplicationUser with data from RegistrarDTO
            ApplicationUser user = new ApplicationUser
            {
                Email = registrarDTO.Email,
                PhoneNumber = registrarDTO.Phone,
                UserName = registrarDTO.Email,
                NombreCompleto = registrarDTO.PersonName,
                Edad = registrarDTO.Edad,
                Role = registrarDTO.Role,
                Direccion = registrarDTO.Direccion,
                LinkedIn = registrarDTO.LinkedIn,
                ImageProfile = registrarDTO.ImageProfile
            };

            // Use UserManager to create and save the user in the database
            var result = await _userManager.CreateAsync(user, registrarDTO.Password);

            if (!result.Succeeded)
            {
                // Collect and display errors from the user creation process
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registrarDTO);
            }

            // Sign in the user after successful registration
            await _signInManager.SignInAsync(user, isPersistent: false);

            // Redirect to the specified area, controller, and action
            return RedirectToAction("Index", "Home", new { area = "Cliente" });
        }



        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "Cliente" });
        }

        // GET 

        [AllowAnonymous]
        public IActionResult IniciarSesion()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> IniciarSesion(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage);
                return View(loginDTO);
            }

            // Attempt to sign in the user
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Redirect to the default area or return URL
                return RedirectToAction("Index", "Home", new { area = "Cliente" });
            }

            ModelState.AddModelError("IniciarSesion", "Invalid email or password");
            return View(loginDTO);
        }

        // GET: CuentaController/Perfil

        public IActionResult Perfil()
        {
            return View();
        }


        // GET: CuentaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CuentaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuentaController/Create
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

        // GET: CuentaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CuentaController/Edit/5
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

        // GET: CuentaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CuentaController/Delete/5
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