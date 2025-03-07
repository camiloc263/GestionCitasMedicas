using MediatR;
using Persona.Application.DTO;
using Persona.Domain.Entities;

namespace Persona.Application.Queries
{
	public class GetPersonaByDocumentoQuery : IRequest<ListaPersona>
    {
        public string NumeroDocumento { get; }

        public GetPersonaByDocumentoQuery(string numeroDocumento)
        {
            NumeroDocumento = numeroDocumento;
        }
    }
}