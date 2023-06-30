using Microsoft.AspNetCore.Routing.Constraints;
using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
    public interface IDatosDelPago
    {
        void add(DatosDelPago datosPago);
        public void guardarTarjeta(string tarjetaaa, decimal monto, int idPersona);
        public TbFactura guardarFactura(string tarjetaaa, decimal monto, int idPersona);
        public string idFacLargo(int idd);
        IEnumerable<TbFactura> GetAllFacturas(int identiC);
        IEnumerable<TbDetallecompra> GetAllDetallesFactura(int IDF);
        IEnumerable<TbTarjetaRecarga> GetAllRecargas(int iddCC);
        void guardarRecarga(TbTarjetaRecarga obj, int numeroTarjeta);
        decimal sumaRecargas(int idDelCliente);
        int sumaPuntos(int idCCC);
        public void limpiarD();
        public void AgregarPeliculas(int iddCCC);
        IEnumerable<TodasMisPeliculas> GelAllPells();
        public void limpiarTTT();
    }
}
