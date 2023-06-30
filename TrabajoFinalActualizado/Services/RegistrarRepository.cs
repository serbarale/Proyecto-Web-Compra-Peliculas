using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
    public class RegistrarRepository : IRegistrar
    {
        private VentasC conexion = new VentasC();
        public void add(TbCliente obj)
        {
            conexion.TbClientes.Add(obj);
            conexion.SaveChanges();
        }
    }
}
