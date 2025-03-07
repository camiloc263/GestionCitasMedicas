using AutoMapper;
using Persona.Application.Queries;
using Persona.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using MediatR;
using Persona.Domain.Entities;

namespace Persona.Application.Commands
{
	public class GetPersonaByDocumentoCommands
    {
        private readonly IPersonaRepository _personaRepository;

        public GetPersonaByDocumentoCommands(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<ListaPersona> Handle(GetPersonaByDocumentoQuery request, CancellationToken cancellationToken)
        {
            return await _personaRepository.GetByDocumentoAsync(request.NumeroDocumento);
        }
    }
}