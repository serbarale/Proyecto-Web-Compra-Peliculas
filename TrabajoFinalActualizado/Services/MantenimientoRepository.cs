using TrabajoFinalActualizado.Models;
using Microsoft.EntityFrameworkCore;

namespace TrabajoFinalActualizado.Services
{
    public class MantenimientoRepository: IMantenimiento
    {
        private VentasC conexion = new VentasC();
        public void add(TbPelicula obj)
        {
            conexion.TbPeliculas.Add(obj);
            conexion.SaveChanges();
        }

        public TbPelicula edit(int id)
        {
            var objEncontrado = (from tpeli in conexion.TbPeliculas
                                 where tpeli.IdPelicula == id
                                 select tpeli).Single();

            return objEncontrado;
        }

        public void editDetails(TbPelicula obj)
        {
            var objModificar = (from tpeli in conexion.TbPeliculas
                                where tpeli.IdPelicula == obj.IdPelicula
                                select tpeli).FirstOrDefault();

            if (objModificar != null)
            {
                objModificar.Titulo = obj.Titulo;
                objModificar.GeneroId = obj.GeneroId;
                objModificar.Duracion = obj.Duracion;
                objModificar.Sinopsis = obj.Sinopsis;
                objModificar.FechaLanzamiento = obj.FechaLanzamiento;
                objModificar.Precio = obj.Precio;
                objModificar.ImagenUrl = obj.ImagenUrl;
            }
            conexion.SaveChanges();
        }

        public IEnumerable<TbPelicula> GetAllPeliculas()
        {
            return conexion.TbPeliculas;
        }

        public IEnumerable<TbPelicula> GetAllPeliculasConGenero()
        {
            return conexion.TbPeliculas.Include(p => p.Genero).ToList();
        }

        public void remove(int id)
        {
            var objEncontrado = (from tpeli in conexion.TbPeliculas
                                 where tpeli.IdPelicula == id
                                 select tpeli).Single();

            conexion.TbPeliculas.Remove(objEncontrado);
            conexion.SaveChanges();
        }
    }
}
