using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
	public interface IPelicula
	{
		IEnumerable<TbPelicula> GetAllPeliculas();
		TbPelicula GetProducto(int codigo);
        IEnumerable<TbPelicula> GetGeneros(int codigo);
        string mostrarGenero(int codigo);

    }
}
