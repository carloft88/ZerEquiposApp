using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace EPP.Models
{
    public class Empleado
    {
        [Key]
        public int empleadoID { get; set; }

        [Required(ErrorMessage ="El nombre es Obligatorio")]
        [Display(Name = "Nombre Empleado") ]
        public string Nombre { get; set; }


        public int cedula { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [Required]
        public int empresaID { get; set; }
        [ForeignKey("empresaID")]                     
        public virtual Empresa Empresa { get; set; }


        [Required]
        public int cargoID { get; set; }
        [ForeignKey("cargoID")]
        public virtual Cargo Cargo { get; set; }


    }
}
