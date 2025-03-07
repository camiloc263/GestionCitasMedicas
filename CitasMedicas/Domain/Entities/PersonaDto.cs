using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasMedicas.Domain.Entities
{
	public class PersonaDto
	{
        internal int? idpaciente;

        public string Nombre { get; set; }
        public int idPersona { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}