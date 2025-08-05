using AspNetCoreGeneratedDocument;
using CatalogoTiendaWeb.Models;
using CatalogoWeb.Data;
using CatalogoWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoTiendaWeb.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
        }

        [HttpGet]
        public Task<IActionResult> Index()
        {
            return Task.FromResult<IActionResult>(View());
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario usuario)
        {
            var usuarioValido = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == usuario.Correo && u.Contrasena == usuario.Contrasena);

            if (usuarioValido != null)
            {
                HttpContext.Session.SetString("Rol", usuarioValido.Rol);
                HttpContext.Session.SetInt32("UsuarioId", usuarioValido.Id);

                // Redirección según el rol
                if (usuarioValido.Rol == "ADMIN")
                {
                    return RedirectToAction("Index", "Home"); // o tu panel de admin
                }
                else if (usuarioValido.Rol == "CLIENTE")
                {
                    return RedirectToAction("AgregarAlCarrito", "Usuarios"); // o página de compra
                }
                else
                {
                    ViewBag.Error = "Rol no reconocido.";
                    return View();
                }
            }

            ViewBag.Error = "Credenciales incorrectas.";
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            // Validar que el correo no exista ya
            var existe = await _context.Usuarios
                .AnyAsync(u => u.Correo == usuario.Correo); // Aquí debe ser tipo string

            if (existe)
            {
                ViewBag.Error = "El correo ya está registrado.";
                return View(usuario);
            }

            // Establecer rol como cliente
            usuario.Rol = "CLIENTE";

            // Guardar en la base de datos
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Usuarios");
        }

        [HttpGet]
        public async Task<IActionResult> AgregarAlCarrito()
        {
            var productos = await _context.Productos.ToListAsync();
            return View(productos);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarAlCarrito(int idProducto, int cantidad)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
            {
                ViewBag.Mensaje = "Debe iniciar sesión para comprar.";
            }
            else
            {
                // Buscar el producto por su ID
                var producto = await _context.Productos.FindAsync(idProducto);

                if (producto != null)
                {
                    ViewBag.Mensaje = $"Agregaste: {cantidad} unidad(es) de \"{producto.Nombre}\" al carrito.";
                }
                else
                {
                    ViewBag.Mensaje = "Producto no encontrado.";
                }
            }

            // Volvemos a cargar los productos para que la vista se refresque correctamente
            var productos = await _context.Productos.ToListAsync();
            return View(productos); // <-- vista que muestra el catálogo
        }

        public async Task<IActionResult> Filtrar(string filtro)
        {
            var productos = await _context.Productos.ToListAsync();

            if (!string.IsNullOrEmpty(filtro))
            {
                filtro = filtro.ToLower();
                productos = productos
                    .Where(p => p.Nombre.ToLower().Contains(filtro) || p.Descripcion.ToLower().Contains(filtro))
                    .ToList();
                ViewBag.Filtro = filtro;
            }

            return View("AgregarAlCarrito", productos); // ¡Aquí estaba el problema!
        }

        [HttpPost]
        public IActionResult Salir()
        {
            
            HttpContext.Session.Clear(); // Borra la sesión
            return RedirectToAction("GraciasPorVisitar");
        }

        public IActionResult GraciasPorVisitar()
        {
            ViewBag.BloquearLayout = true; // Oculta header y footer
            return View();
        }

        [HttpPost]
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear(); // Borra toda la sesión
            return RedirectToAction("Index", "Usuarios"); // O a donde quieras redirigir
        }
    }
}