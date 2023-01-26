using System.ComponentModel.DataAnnotations;

namespace EPP.Models
{
    public class Empresa
    {
        [Key]
        public int empresaId { get; set; }

        [Required]
        [Display(Name = "Nombre Empresa")]
        public string NOmbre { get; set; }

    }
}
