using Microsoft.AspNetCore.Mvc;
using TrabajoFinalActualizado.Models;
using TrabajoFinalActualizado.Services;

namespace TrabajoFinal.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly IDatosDelPago _datosDelPago;
        private readonly IVentaTemporal _ventaT;
        private readonly IUserTemporal _userTemporal;
        private readonly IUsuario _usuario;
        public FacturacionController(IDatosDelPago datosdelpago, IVentaTemporal ventaT, IUserTemporal userTemporal, IUsuario usuario)
        {
            _ventaT = ventaT;
            _datosDelPago = datosdelpago;
            _userTemporal = userTemporal;
            _usuario = usuario;
        }
        public IActionResult Facturacion(DatosDelPago obj)
        {
            _datosDelPago.add(obj);
            decimal totalsumado = _ventaT.totalSuman();
            string tipoTarjeta = obj.tipoDeTarjetaPPagar;
            int id = _userTemporal.obtenID();

            decimal sumaRecargas =_datosDelPago.sumaRecargas(id);
            decimal totalGuardarenDB = sumaRecargas - totalsumado;
            if(tipoTarjeta== "TARJETA DE LA EMPRESA")
            {
                if (totalGuardarenDB < 0)
                {
                    ViewData["montttt"] = totalsumado;
                    return RedirectToAction("menorqueCero", "Facturacion");
                }
                else
                {
                    _datosDelPago.guardarTarjeta(tipoTarjeta, totalsumado, id);
                    var objFac = _datosDelPago.guardarFactura(tipoTarjeta, totalsumado, id);
                    int idF = objFac.IdFactura;
                    _ventaT.guardarDetalleFactura(idF);
                    ViewData["fecha"] = objFac.FechaFactura;
                    string IDFFF = _datosDelPago.idFacLargo(idF);
                    ViewData["numeroFac"] = IDFFF;
                    decimal totalPagaaar = (decimal)objFac.Total;
                    ViewData["Total"] = totalPagaaar;
                    ViewData["FormaPagoo"] = objFac.FormaDePago;
                    var Cliente = _usuario.editarClientes(id);
                    ViewData["nom"] = Cliente.NombreCliente;
                    ViewData["ape"] = Cliente.ApellidoCliente;
                    ViewData["corr"] = Cliente.CorreoCliente;
                    ViewData["dir"] = Cliente.DireccionCliente;

                    return View(_ventaT.obtenerTodasLasVTemporales());
                }
            }
            else
            {
                _datosDelPago.guardarTarjeta(tipoTarjeta, totalsumado, id);
                var objFac = _datosDelPago.guardarFactura(tipoTarjeta, totalsumado, id);
                int idF = objFac.IdFactura;
                _ventaT.guardarDetalleFactura(idF);
                ViewData["fecha"] = objFac.FechaFactura;
                string IDFFF = _datosDelPago.idFacLargo(idF);
                ViewData["numeroFac"] = IDFFF;
                decimal totalPagaaar = (decimal)objFac.Total;
                ViewData["Total"] = totalPagaaar;
                ViewData["FormaPagoo"] = objFac.FormaDePago;
                var Cliente = _usuario.editarClientes(id);
                ViewData["nom"] = Cliente.NombreCliente;
                ViewData["ape"] = Cliente.ApellidoCliente;
                ViewData["corr"] = Cliente.CorreoCliente;
                ViewData["dir"] = Cliente.DireccionCliente;

                return View(_ventaT.obtenerTodasLasVTemporales());
            }  
        }

        public IActionResult menorqueCero()
        {
            return View();
        }
        public IActionResult limpiarTodo()
        {
            _ventaT.limpiarT();
            _datosDelPago.limpiarD();
            return RedirectToAction("Index", "Pelicula");
        }

        [Route("Facturacion/verFacturas/{codigo}")]
        public IActionResult verFacturas(int codigo)
        {
            ViewData["cod"] = codigo;
            return View(_datosDelPago.GetAllFacturas(codigo));
        }
        public IActionResult boletaDetallada(string txtIdFactura, string txtFecha, 
                             string txtTipoPago, string txtTotal, string txtIdCliente)
        {
            int idC = int.Parse(txtIdCliente);
            int idF = int.Parse(txtIdFactura);
            ViewData["fecha"] = txtFecha;
            ViewData["tipoP"] = txtTipoPago;
            decimal totT = decimal.Parse(txtTotal);
            ViewData["total"] = totT;
            string IDFFF = _datosDelPago.idFacLargo(idF);
            ViewData["idFac"] = IDFFF;
            var Cliente = _usuario.editarClientes(idC);
            ViewData["idClienteeee"] = idC;
            ViewData["nom"] = Cliente.NombreCliente;
            ViewData["ape"] = Cliente.ApellidoCliente;
            ViewData["corr"] = Cliente.CorreoCliente;
            ViewData["dir"] = Cliente.DireccionCliente;

            return View(_datosDelPago.GetAllDetallesFactura(idF));
        }
    }
}
