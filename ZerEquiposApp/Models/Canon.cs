using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EPP.Models
{
    public class Canon
    {

        [Key]
        public int CanonId { get; set; }

        [Required(ErrorMessage = "El nombre de la Canon es obligatio")]
        [Display(Name = "Nombre Canon")]
        public string Nombre { get; set; }
    }
}
