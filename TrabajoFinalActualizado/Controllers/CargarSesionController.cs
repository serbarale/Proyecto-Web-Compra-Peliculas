using Microsoft.AspNetCore.Mvc;
using TrabajoFinalActualizado.Models;
using TrabajoFinalActualizado.Services;

namespace TrabajoFinal.Controllers
{
    public class CargarSesionController : Controller
    {
        private readonly IRegistrar _registrar;
        public CargarSesionController(IRegistrar registrar)
        {
            _registrar = registrar;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registrar()
        {
            return View();
        }
        public IActionResult LoginAdmin()
        {
            return View();
        }
        public IActionResult Pasar_Registro(TbCliente obj)
        {
            _registrar.add(obj);
            return RedirectToAction("Index", "CargarSesion");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
