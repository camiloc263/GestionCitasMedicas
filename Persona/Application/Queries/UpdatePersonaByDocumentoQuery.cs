using MediatR;
using Persona.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persona.Application.Queries
{
	public class UpdatePersonaByDocumentoQuery : IRequest<bool>
    {
        public string NumeroDocumento { get; set; }
        public PersonasDto Persona { get; set; }

        public UpdatePersonaByDocumentoQuery(string numeroDocumento, PersonasDto persona)
        {
            NumeroDocumento = numeroDocumento;
            Persona = persona;
        }
    }
}