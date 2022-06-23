using Practicaweb.API.Models;

namespace Practicaweb.API.Models
{
    public class PeliculaDto //Consultas
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty; //Esto es vacio no nulo
        public string? Description { get; set; } //Se utiliza ? para darle la opcion de nulo
        public IList<ActorDto> Actores { get; set; } = new List<ActorDto>(); // Creamos una lista de actores como propiedad de cada pelicula
        public int CantidadDeActores
        {
            get { return Actores.Count; }
        }
    }
}
