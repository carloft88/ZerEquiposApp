using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EPP.Models
{
    public class Licenciamiento
    {
        [Key]
        public int licenciamientoId { get; set; }

        [Required(ErrorMessage = "El nombre del licenciamiento es obligatio")]
        [Display(Name = "Nombre del licenciamiento")]
        public string Nombre { get; set; }
    }
}
