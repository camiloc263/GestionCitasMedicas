using MediatR;
using Persona.Application.DTO;
using Persona.Domain.Entities;
using System.Collections.Generic;

namespace Persona.Application.Queries
{
	public class GetPersonasByTipoUsuarioQuery: IRequest<List<ListaPersona>>
    {
        public string TipoUsuario { get; }


        public GetPersonasByTipoUsuarioQuery(string tipoUsuario)
        {
            TipoUsuario = tipoUsuario;
        }
    }
}