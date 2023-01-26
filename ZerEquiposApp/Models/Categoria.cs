using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EPP.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El nombre de la Categoria es obligatio")]
        [Display(Name = "Nombre Categoria")]
        public string Nombre { get; set; }

    }
}
