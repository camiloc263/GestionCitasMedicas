using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Persona.Application.DTO
{
	public class PersonasDto
	{
        public int id { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string nombre { get; set; }
        public string apellidoUno { get; set; }
        public string apellidoDos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public string tipoUsuario { get; set; }
    }
}