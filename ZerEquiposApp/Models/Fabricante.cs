using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EPP.Models
{
    public class Fabricante
    {

        [Key]
        public int FrabricanteId { get; set; }

        [Required(ErrorMessage = "El nombre Frabricante obligatio")]
        [Display(Name = "Nombre Frabricante")]
        public string Nombre { get; set; }
    }
}
