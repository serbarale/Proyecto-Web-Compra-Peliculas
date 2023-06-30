using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
	public class PeliculaRepository : IPelicula
	{
		VentasC conexion = new VentasC();

        public IEnumerable<TbPelicula> GetAllPeliculas()
		{
			return conexion.TbPeliculas;
		}

		public TbPelicula GetProducto(int codigo)
		{
			var objEncontrado = (from tpro in conexion.TbPeliculas
								 where tpro.IdPelicula == codigo
								 select tpro).Single();//LINQ
			return objEncontrado;
		}

        public IEnumerable<TbPelicula> GetGeneros(int codigo)
        {
            var objEncontrado = (from tpeli in conexion.TbPeliculas where tpeli.GeneroId == codigo select tpeli).ToList();
            return objEncontrado;
        }

        public string mostrarGenero(int codigo)
        {
            var objEncontrado = (from tmost in conexion.TbPeliculas
                                 where tmost.IdPelicula == codigo
                                 select tmost).Single();//LINQ
            int genero = objEncontrado.GeneroId;

            var objEncontrado2 = (from tver in conexion.TbGeneros
                                  where tver.IdGenero == genero
                                  select tver).Single();//LINQ
            return objEncontrado2.NombreGenero;
        }
    }
}
