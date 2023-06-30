using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
	public class VentaTemporalRepository : IVentaTemporal
	{
		private List<VentaTemporal> lst = new List<VentaTemporal>();

        VentasC conexion = new VentasC();
        public void add(VentaTemporal Vtemporal)
		{
			lst.Add(Vtemporal);
		}
        public void limpiarT()
        {
            lst.Clear();
        }
        public IEnumerable<VentaTemporal> obtenerTodasLasVTemporales()
		{
			return lst;
		}
        public bool compararAntesDeAgregar(string codigo)
        {
            var objAModificar = lst.Where(tpro => tpro.codigoV == int.Parse(codigo)).FirstOrDefault();

            if(objAModificar != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void guardar1(string codigo,string precio)
        {
            var objAModificar = lst.Where(tpro => tpro.codigoV == int.Parse(codigo)).FirstOrDefault();
            if (objAModificar != null)
            {
                int cant2 = objAModificar.cantidadV + 1;
                decimal total2 = cant2 * decimal.Parse(precio);
                // El código ya existe, actualiza la cantidad y el total
                objAModificar.cantidadV = cant2;
                objAModificar.totalV = total2;

            }

        }

       public decimal totalSuman()
        {
            decimal  tot = 0;
            for(int i=0; i<lst.Count; i++)
            {
                tot = tot + lst[i].totalV;
            }
            return tot;
        }
        public void guardarDetalleFactura(int idFactura)
        {
            
            for (int i = 0; i < lst.Count; i++)
            {
                TbDetallecompra tbDetallecompra = new TbDetallecompra();

                tbDetallecompra.IdFactura = idFactura;
                tbDetallecompra.IdPelicula = lst[i].codigoV;
                tbDetallecompra.Cantidad = lst[i].cantidadV;
                tbDetallecompra.PrecioUnitario = (decimal)lst[i].precioV;
                tbDetallecompra.SubTotal = (decimal)lst[i].totalV;
                conexion.TbDetallecompras.Add(tbDetallecompra);
                conexion.SaveChanges();
            }
            
        }

        public void remove(string id)
        {
            var objEncontrado = lst.Where(tpro => tpro.codigoV == int.Parse(id)).Single();
            lst.Remove(objEncontrado);
        }
        public VentaTemporal edit(string IDD)
        {
            var objEncontrado = lst.Where(tpro => tpro.codigoV == int.Parse(IDD)).Single();
            return objEncontrado;
        }
        public void editDetails(VentaTemporal obj)
        {
            var objAModificar = lst.Where(tpro => tpro.codigoV == obj.codigoV).FirstOrDefault();
            if (objAModificar != null)
            {
                decimal total = obj.cantidadV * obj.precioV;

                objAModificar.cantidadV = obj.cantidadV;
                objAModificar.totalV = total;
            }
        }
    }
}
