using Practicaweb.API.Models;

namespace Practicaweb.API
{
    public class PeliculasData  // "Base de datos  xD"
    {
        public static PeliculasData UniqueInstance { get; } = new PeliculasData(); // Permite que se mantenga el orden de la lista
        public List<PeliculaDto> Peliculas { get; set; }

        public PeliculasData()
        {
            Peliculas = new List<PeliculaDto>
            {
                new PeliculaDto()
                {
                    Id = 1,
                    Name = "Titanick",
                    Description = "Increible",
                    Actores = new List<ActorDto>
                    {
                        new ActorDto()
                        {
                            Id = 1,
                            Name = "Nick Gaturro",

                        },
                        new ActorDto()
                        {
                            Id = 2,
                            Name = "Jesica Cirio",

                        },
                        new ActorDto()
                        {
                            Id = 3,
                            Name = "El Duki",

                        }
                    }
                },
                new PeliculaDto()
                {
                    Id = 2,
                    Name = "Marcianos al ataque",
                    Description = "Obra maestra",
                    Actores = new List<ActorDto>
                    {
                        new ActorDto()
                        {
                            Id = 4,
                            Name = "Alfredo Casero",

                        },
                        new ActorDto()
                        {
                            Id = 5,
                            Name = "Tinelli",

                        },
                        new ActorDto()
                        {
                            Id = 6,
                            Name = "Pinion Fijo",

                        }
                    }
                },
                new PeliculaDto()
                {
                    Id = 3,
                    Name = "Sonick",
                    Description = "Mejoro luego del retoque a la cara",
                    Actores = new List<ActorDto>
                    {
                        new ActorDto()
                        {
                            Id = 7,
                            Name = "Marcos Rojo",

                        },
                        new ActorDto()
                        {
                            Id = 8,
                            Name = "Luquita Rodriguez",

                        },
                        new ActorDto()
                        {
                            Id = 9,
                            Name = "Lgante",

                        }
                    }
                }
            };
        }
    }
}
