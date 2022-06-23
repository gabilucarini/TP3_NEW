using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Practicaweb.API.Models;

namespace Practicaweb.API.Controllers
{
    [ApiController]
    [Route("api/peliculas/{idPelicula}/actores")] // Forzamos a que los actores dependan de una pelicula
    public class ActoresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ActorDto>> GetActores(int idPelicula)
        {
            var Pelicula = PeliculasData.UniqueInstance.Peliculas.Where(x => x.Id == idPelicula).FirstOrDefault();
            if (Pelicula == null)
            {
                return NotFound();
            }
            return Ok(Pelicula.Actores);
        }

        [HttpGet("{idActores}", Name = "GetActores")]


        public ActionResult<ActorDto> GetActores(int idPelicula, int idActores)
        {
            var Pelicula = PeliculasData.UniqueInstance.Peliculas.Where(x => x.Id == idPelicula).FirstOrDefault();
            if (Pelicula == null)
            {
                return NotFound();
            }

            var Actores = Pelicula.Actores.Where(x => x.Id == idActores).FirstOrDefault();
            if (Actores == null)
            {
                return NotFound();
            }
            return Ok(Actores);
        }

        [HttpPost] //Crear

        public ActionResult<ActorDto> CrearActor(int idPelicula, ActoresCreacionDto actorACrear)
        {
            var Pelicula = PeliculasData.UniqueInstance.Peliculas.Where(x => x.Id == idPelicula).FirstOrDefault();
            if (Pelicula == null)
            {
                return NotFound();
            }

            var idMaxActores = PeliculasData.UniqueInstance.Peliculas.SelectMany(c => c.Actores).Max(p => p.Id);  //Selectmany crea una lista a partir de las lista seleccionada dentro
            //Se selecciona la IP máxima en actores y se crea un nuevo actor
            var nuevoActor = new ActorDto
            {
                Id = idMaxActores + 1, // se le suma +1 a la lista de actores
                Name = actorACrear.Nombre
            };

            Pelicula.Actores.Add(nuevoActor);

            return CreatedAtRoute("GetActores",
                new
                {
                    idPelicula,
                    idActores = nuevoActor.Id
                },
                nuevoActor);

        }
        [HttpPut("{idActores}")] //Modificar

        public ActionResult<ActorDto> ModificarActor(int idPelicula, int idActores, ActoresActualizarDto actorActualizado)
        {
            var Pelicula = PeliculasData.UniqueInstance.Peliculas.Where(x => x.Id == idPelicula).FirstOrDefault();
            if (Pelicula == null)
            {
                return NotFound();
            }

            var ActorAActualizar = Pelicula.Actores.Where(x => x.Id == idActores).FirstOrDefault();
            if (ActorAActualizar == null)
            {
                return NotFound();
            }

            ActorAActualizar.Name = actorActualizado.Nombre;

            return NoContent();
        }

        [HttpDelete("{idActores}")]

        public ActionResult EliminarActor(int idPelicula, int idActores)
        {
            var Pelicula = PeliculasData.UniqueInstance.Peliculas.Where(x => x.Id == idPelicula).FirstOrDefault();
            if (Pelicula == null)
            {
                return NotFound();
            }

            var ActorAEliminar = Pelicula.Actores.Where(x => x.Id == idActores).FirstOrDefault();
            if (ActorAEliminar == null)
            {
                return NotFound();
            }

            Pelicula.Actores.Remove(ActorAEliminar);

            return NoContent();
        }
    }
}
