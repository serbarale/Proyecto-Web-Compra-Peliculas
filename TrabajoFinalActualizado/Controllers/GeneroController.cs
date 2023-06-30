using Microsoft.AspNetCore.Mvc;
using TrabajoFinalActualizado.Models;
using TrabajoFinalActualizado.Services;

namespace TrabajoFinalActualizado.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGenero _genero;
        private readonly IPelicula _pelicula;

        public GeneroController(IGenero genero, IPelicula pelicula)
        {
            _genero = genero;
            _pelicula = pelicula;
        }

        [Route("/Genero")]
        public IActionResult Index()
        {
            return View(_genero.GetAllGeneros());
        }

        [Route("/Genero/Listar/{id}")]
        public IActionResult ListarPeliculas(int id)
        {
            return View(_pelicula.GetGeneros(id));
        }
    }
}
