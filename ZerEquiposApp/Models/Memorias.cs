using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EPP.Models
{
    public class Memorias
    {
        [Key]
        public int memoriaId { get; set; }

        [Required(ErrorMessage ="El nombre de la memoria es obligatio")]
        [Display(Name = "Nombre Memoria")]
        public string NOmbre { get; set; }

    }
}
