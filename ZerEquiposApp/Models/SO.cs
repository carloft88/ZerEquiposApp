using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EPP.Models
{
    public class SO
    {
        [Key]
        public int SoId { get; set; }

        [Required(ErrorMessage = "El nombre del sistema operativo es obligatio")]
        [Display(Name = "Nombre del sistema operativo")]
        public string Nombre { get; set; }
    }
}
