using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EPP.Models
{
    public class Procesador
    {
        [Key]
        public int procesadorId { get; set; }

        [Required(ErrorMessage = "El nombre del Procesador es obligatio")]
        [Display(Name = "Nombre Memoria")]
        public string Nombre { get; set; }
        public int Genracion { get; set; }

    }
}
