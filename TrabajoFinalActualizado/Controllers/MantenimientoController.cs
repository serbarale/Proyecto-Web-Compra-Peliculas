using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrabajoFinalActualizado.Models;
using TrabajoFinalActualizado.Services;

namespace TrabajoFinalActualizado.Controllers
{
    public class MantenimientoController : Controller
    {
        private readonly IMantenimiento _mantenimiento;

        public MantenimientoController(IMantenimiento mandenimiento)
        {
            _mantenimiento = mandenimiento;
        }
        public IActionResult Index()
        {
            var objSession = HttpContext.Session.GetString("sAdmin");

            if (objSession != null)
            {
                var obj = JsonConvert.DeserializeObject<TbAdministradore>
                    (HttpContext.Session.GetString("sAdmin"));

                return View(_mantenimiento.GetAllPeliculasConGenero());
            }
            else
            {
                return RedirectToAction("Privacy", "Home");
            }
        }

        public IActionResult Nuevo()
        {
            return View();
        }
        public IActionResult Grabar(TbPelicula obj)
        {
            _mantenimiento.add(obj);
            return RedirectToAction("Index");
        }
        [Route("Mantenimiento/Editar/{id}")]
        public IActionResult Editar(int id)
        {
            return View(_mantenimiento.edit(id));
        }
        public IActionResult EditarPelicula(TbPelicula obj)
        {
            _mantenimiento.editDetails(obj);
            return RedirectToAction("Index");
        }
        [Route("Mantenimiento/Eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            return View(_mantenimiento.edit(id));
        }
        public IActionResult EliminarPelicula(int id)
        {
            _mantenimiento.remove(id);
            return RedirectToAction("Index");
        }
        [Route("Mantenimiento/Detalles/{id}")]
        public IActionResult Detalles(int id)
        {
            return View(_mantenimiento.edit(id));
        }
    }
}
