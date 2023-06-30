using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrabajoFinalActualizado.Models;
using TrabajoFinalActualizado.Services;

namespace TrabajoFinalActualizado.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IUserTemporal _userTemporal;
        private readonly IUsuario _usuario;
        private readonly IDatosDelPago _datosDelPago;
        public PerfilController(IUserTemporal userT, IUsuario usuario, IDatosDelPago datosDelPago)
        {
            _userTemporal = userT;
            _usuario = usuario;
            _datosDelPago = datosDelPago;
        }
        public IActionResult Perfil()
        {           
             var objSession = HttpContext.Session.GetString("sCliente");

            if (objSession != null)
            {
                var obj = JsonConvert.DeserializeObject<MemoryUser>
                    (HttpContext.Session.GetString("sCliente"));

                return View(_userTemporal.GelAllTemporarySale());
            }
            else
            {
                return RedirectToAction("Index", "CargarSesion");
            }
        }

        public IActionResult ActualizarPerfil(string txtcodigo, string txtnombre)
        {
            int codigo=int.Parse(txtcodigo);
            ViewData["nom"] = txtnombre;
            

            return View(_usuario.editarClientes(codigo));           
        }
        public IActionResult pasarInfNueva(TbCliente obj)
        {
            _usuario.editandoLosDatos(obj);
            return RedirectToAction("Perfil", "Perfil");
        }
        //PARA LAS TARJETAS
        [Route("Perfil/ObtenerNuestraTarjeta/{codigo}")]

        public IActionResult ObtenerNuestraTarjeta(int codigo)
        {
            if (_userTemporal.comprobarTarjeta(codigo) == "NO")
            {
                ViewData["aaa"] = codigo;
                return View();
            }
            else if (_userTemporal.comprobarTarjeta(codigo) == "SI")
            {
                return RedirectToAction("Obtener222NuestraTarjeta", "Perfil");
            }
            else
            {
                return RedirectToAction("Error", "CargarSesion");
            }
        }
        [Route("Perfil/Obtener111NuestraTarjeta/{codigo}")]
        public IActionResult Obtener111NuestraTarjeta (int codigo)
        {
            _usuario.add(codigo);
            _usuario.editDetails(codigo);
            return RedirectToAction("Perfil", "Perfil");
        }
        public IActionResult Obtener222NuestraTarjeta()
        {
            return View();
        }

        [Route("Perfil/TarjetaObtenida/{codigo}")]
        public IActionResult TarjetaObtenida(int codigo)
        {
            decimal sumaRR =_datosDelPago.sumaRecargas(codigo);
            ViewData["sumaR"] = sumaRR;
            int sumaPP = _datosDelPago.sumaPuntos(codigo);
            ViewData["sumaPPPP"] = sumaPP;
            if (_userTemporal.comprobarTarjeta(codigo) == "NO")
            {
                return RedirectToAction("Obtener333NuestraTarjeta", "Perfil");
            }
            else if (_userTemporal.comprobarTarjeta(codigo) == "SI")
            {
                return View(_usuario.GetTarjetaEmpresa(codigo));
            }
            else
            {
                return RedirectToAction("Error", "CargarSesion");
            }
            
        }
        public IActionResult Obtener333NuestraTarjeta()
        {
            return View();
        }
        public IActionResult RecargarTarjeta(string txtnumTar)
        {
            ViewData["codTar"] = txtnumTar;
            return View();
        }
        public IActionResult Comprobacion(TbTarjetaRecarga obj)
        {
            int idCliente = _userTemporal.obtenID();
            _datosDelPago.guardarRecarga(obj, idCliente);
            return RedirectToAction("HistorialDeRecargas", "Perfil");
        }
        public IActionResult HistorialDeRecargas()
        {
            int idCliente = _userTemporal.obtenID();
            return View(_datosDelPago.GetAllRecargas(idCliente));
        }
        public IActionResult verTodasMisPeliculasCompradas()
        {
            _datosDelPago.limpiarTTT();
            int idCliente = _userTemporal.obtenID();
            _datosDelPago.AgregarPeliculas(idCliente);
            return View(_datosDelPago.GelAllPells());
        }
        
    }
}
