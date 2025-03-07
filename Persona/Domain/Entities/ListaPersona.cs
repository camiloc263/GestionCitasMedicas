namespace Persona.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

  
    public partial class ListaPersona
    {
        public int id { get; set; }

        [StringLength(20)]
        public string tipoDocumento { get; set; }

        [StringLength(20)]
        public string numeroDocumento { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string apellidoUno { get; set; }

        [StringLength(50)]
        public string apellidoDos { get; set; }

        [StringLength(10)]
        public string direccion { get; set; }

        [StringLength(10)]
        public string telefono { get; set; }

        [StringLength(50)]
        public string correo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaNacimiento { get; set; }

        [StringLength(20)]
        public string tipoUsuario { get; set; }
    }
}
