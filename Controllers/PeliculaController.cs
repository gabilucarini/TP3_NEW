using Microsoft.AspNetCore.Mvc;

namespace Practicaweb.API.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculaController : ControllerBase
    {   //Inyeccion de dependencias
        /*private readonly PeliculasData _peliculasData; 
        public PeliculaController(PeliculasData peliculasData)
        {
            _peliculasData = peliculasData;
        }*/
        [HttpGet]
        public JsonResult GetPeliculas()
        {
            return new JsonResult(PeliculasData.UniqueInstance.Peliculas);
        }//PeliculasData.UniqueInstance sería _peliculasData con InyeccDep
        [HttpGet("/{id}")]
        public IActionResult GetPeliculas(int idPelicula) // Actionresult empaqueta muchas cosas, permite devolver 404 o el error que sea
        {
            var Pelicula = PeliculasData.UniqueInstance.Peliculas.Where(x => x.Id == idPelicula).FirstOrDefault();
            if(Pelicula == null)
            {
                return NotFound(); // NOt found es un metodo de mvc que retorna 404
            }
            return Ok(Pelicula); // retorna 200
        }
    }
}
