namespace CitasMedicas.Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class CitaMedica
    {
        public CitaMedica() { }

        [Key]
        public int idcita { get; set; }

        public int? idpaciente { get; set; }

        public int? idmedico { get; set; }

        [StringLength(50)]
        public string lugarcita { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechacita { get; set; }

        [StringLength(50)]
        public string estadocita { get; set; }

        
        [NotMapped] 
        public string codigoReceta { get; set; }
        [NotMapped]
        public DateTime? FechaEmision { get; set; }
        [NotMapped] 
        public string estado { get; set; }
        [NotMapped]
        public DateTime? fechaVencimiento { get; set; }
        [NotMapped]
        public string descripcion { get; set; }

       

    }
}
