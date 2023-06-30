using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TrabajoFinalActualizado.Models;
using TrabajoFinalActualizado.Services;

namespace TrabajoFinal.Controllers
{
    public class PeliculaController : Controller
    {
       
        private readonly IUsuario _usuario;
        private readonly IUserTemporal _userTemporal;
        private readonly IPelicula _pelicula;
		private readonly IVentaTemporal _ventaT;


		public PeliculaController(IUsuario usuario, IUserTemporal userT, IPelicula pelicula, IVentaTemporal ventaT)
        {
            _usuario = usuario;
            _userTemporal = userT;
            _pelicula = pelicula;
			_ventaT = ventaT;

		}

        public IActionResult Comprobacion(MemoryUser obj)
        {
            if (_usuario.compararUsuario(obj) == true)
            {
                HttpContext.Session.SetString("sCliente",
                    JsonConvert.SerializeObject(obj));/*crear la sesion*/
                _userTemporal.add(obj);
                _userTemporal.edit(obj);
                return RedirectToAction("Index", "Pelicula");          
            }
            else
            {
                return RedirectToAction("Index", "CargarSesion");
            }
        }
        public IActionResult ValidarAdmin(TbAdministradore objadmin)
        {
            if(_usuario.ValidarAdmin(objadmin) == true)
            {
                HttpContext.Session.SetString("sAdmin",
                    JsonConvert.SerializeObject(objadmin));
                return RedirectToAction("Index","Mantenimiento");
            }
            else
            {
                return RedirectToAction("LoginAdmin", "CargarSesion");
            }
        }
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Pelicula");
        }
        public IActionResult Index()
        {
			return View(_pelicula.GetAllPeliculas());
		}
		[Route("Pelicula/sobrePelicula/{codigo}")]
		public IActionResult sobrePelicula(int codigo)
        {
            ViewData["gen"] = _pelicula.mostrarGenero(codigo);
            return View(_pelicula.GetProducto(codigo));
		}
        public IActionResult pasarTodo(string txtcodigo, string txtTitulo, string txtGenero, string txtDuracion,
									string txtSinopsis, string txtFecha, string txtprecio, string txtImagen)
        {
            VentaTemporal nuevaVenta = new VentaTemporal();
            if (_ventaT.compararAntesDeAgregar(txtcodigo) == true)
            {
                _ventaT.guardar1(txtcodigo,txtprecio);
            }
            else if(_ventaT.compararAntesDeAgregar(txtcodigo) == false)
            {

                int cantidad = 1;
                decimal preciototal = cantidad * decimal.Parse(txtprecio);

                nuevaVenta.codigoV = int.Parse(txtcodigo);
                nuevaVenta.nombrePeliculaV = txtTitulo;
                nuevaVenta.precioV = decimal.Parse(txtprecio);
                nuevaVenta.cantidadV = cantidad;
                nuevaVenta.totalV = preciototal;
          
                
                _ventaT.add(nuevaVenta);
            }
            
            return RedirectToAction("carritoCompras", "Pelicula");
        }
        public IActionResult carritoCompras()
        {
            var objSession = HttpContext.Session.GetString("sCliente");

            if (objSession != null)
            {
                var obj = JsonConvert.DeserializeObject<MemoryUser>
                    (HttpContext.Session.GetString("sCliente"));
                decimal totalCompra = _ventaT.totalSuman();
                ViewData["totalCompra"] = totalCompra;

                return View(_ventaT.obtenerTodasLasVTemporales());
            }
            else
            {
                return RedirectToAction("Index", "CargarSesion");
            }


		}
        public IActionResult Confirmacion_Pago(string txtmonto)
        {
            decimal MontoFinal  = decimal.Parse(txtmonto);
            ViewData["MontoFinal"] = MontoFinal;
            if (MontoFinal == 0)
            {
                return RedirectToAction("carritoCompras", "Pelicula");
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Generos()
        {
            return View();
        }
        [Route("Pelicula/Eliminar/{idd}")]
        public IActionResult Eliminar(string idd)
        {
            _ventaT.remove(idd);
            return RedirectToAction("carritoCompras");
        }
        [Route("Pelicula/Modificar/{iddd}")]
        public IActionResult Modificar(string iddd)
        {
            return View(_ventaT.edit(iddd));
        }
        public IActionResult ModificarPeliculaa(VentaTemporal obj)
        {
            _ventaT.editDetails(obj);
            return RedirectToAction("carritoCompras");
        }
    }
}
