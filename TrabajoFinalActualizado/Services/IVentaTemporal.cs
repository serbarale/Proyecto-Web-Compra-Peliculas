using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
    public interface IVentaTemporal
    {
		void add(VentaTemporal Vtemporal);
		IEnumerable<VentaTemporal> obtenerTodasLasVTemporales();
        public bool compararAntesDeAgregar(string codigo);
        public void guardar1(string codigo,string precio);
        public decimal totalSuman();
        public void guardarDetalleFactura(int idFactura);
        public void limpiarT();
        public void remove(string id);
        public VentaTemporal edit(string IDD);
        public void editDetails(VentaTemporal obj);
    }
}
