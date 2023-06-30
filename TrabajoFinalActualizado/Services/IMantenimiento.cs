using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
    public interface IMantenimiento
    {
        void add(TbPelicula obj);
        IEnumerable<TbPelicula> GetAllPeliculas();
        void remove(int id);
        TbPelicula edit(int id);
        void editDetails(TbPelicula obj);
        IEnumerable<TbPelicula> GetAllPeliculasConGenero();
    }
}
