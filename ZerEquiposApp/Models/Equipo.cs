using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.Data.SqlTypes;

namespace EPP.Models
{
    public class Equipo
    {
        [Key]
        public int equipoID { get; set; }

        [Required(ErrorMessage = "El nombre es Obligatorio")]
        [Display(Name = "Nombre Equipo")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "La categoria es Obligatoria")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaCompra { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Fecha_fabrica { get; set; }

                
        [Display(Name = "Sistema Operativo")]
        public int SoId { get; set; }
        [ForeignKey("SoId")]
        public virtual SO Sistema { get; set; }

        [Required]
        [Display(Name = "Capacidad de Memoria")]
        public int memoriaId { get; set; }
        [ForeignKey("memoriaId")]
        public virtual Memorias Memoria { get; set; }

        [Required]
        [Display(Name = "Procesador")]
        public int procesadorId { get; set; }
        [ForeignKey("procesadorId")]
        public virtual Procesador Procesador { get; set; }
                       
        
        [Display(Name = "Empleado")]
        public int? empleadoID { get; set; }
        [ForeignKey("empleadoID")]
        public virtual Empleado Empleado{ get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; } = true;

        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Display(Name = "Precio")]
        public double? Precio { get; set; } 

        [Display(Name = "Activo Fijo")]
        public string? activoFijo { get; set; }

        [Display(Name = "Serial")]
        public string serial { get; set; }

        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }

        [Required]
        [Display(Name = "licenciamiento")]
        public int licenciamientoId { get; set; }
        [ForeignKey("licenciamientoId")]
        public virtual Licenciamiento licenciamiento { get; set; }

        [Required]
        [Display(Name = "Fabricante")]
        public int FabricanteId { get; set; }
        [ForeignKey("FabricanteId")]
        public virtual Fabricante Fabricante { get; set; }



        [Required]
        [Display(Name = "Canon")]
        public int CanonId { get; set; }
        [ForeignKey("CanonId")]
        public virtual Canon Canon { get; set; }



    }
}
