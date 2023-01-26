using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EPP.Models
{
    public class Cargo
    {

        [Key]
        public int cargoID { get; set; }

        [Required(ErrorMessage = "El cargo es obligatio")]
        [Display(Name = "Nombre cargo")]
        public string Nombre { get; set; }
    }
}
