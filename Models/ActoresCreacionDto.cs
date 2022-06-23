using System.ComponentModel.DataAnnotations;

namespace Practicaweb.API.Models
{
    public class ActoresCreacionDto
    {
        [Required(ErrorMessage = "Agregue un nombre")]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
    }
}
