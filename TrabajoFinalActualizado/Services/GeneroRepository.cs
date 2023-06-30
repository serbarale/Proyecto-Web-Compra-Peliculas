using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
    public class GeneroRepository : IGenero
    {
        VentasC conexion = new VentasC();

        public IEnumerable<TbGenero> GetAllGeneros()
        {
            return conexion.TbGeneros;
        }
    }
}
