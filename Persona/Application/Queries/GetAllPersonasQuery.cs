using MediatR;
using Persona.Application.DTO;
using Persona.Domain.Entities;
using System.Collections.Generic;


namespace Persona.Application.Queries
{
	public class GetAllPersonasQuery: IRequest<List<ListaPersona>>
	{
	}
}