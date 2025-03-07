using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecetasMedicas.Domain.Entities
{
	public class FormulaMedica
	{
        
        [Key]
        public int IdReceta { get; set; }

        [Required]
        [StringLength(20)]
        public string CodigoReceta { get; set; }

        [Required]
        public int IdPaciente { get; set; }

        [Required]
        public DateTime FechaEmision { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        [Required]
        [StringLength(10)]
        public string Estado { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }
    }
}