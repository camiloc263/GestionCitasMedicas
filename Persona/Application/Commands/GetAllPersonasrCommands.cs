using MediatR;
using Persona.Domain.Interface;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Persona.Application.DTO;
using Persona.Application.Queries;
using Persona.Domain.Entities;
using AutoMapper;

namespace Persona.Application.Commands
{
    public class GetAllPersonasrCommands : IRequestHandler<GetAllPersonasQuery, List<ListaPersona>>
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public GetAllPersonasrCommands(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public async Task<List<ListaPersona>> Handle(GetAllPersonasQuery request, CancellationToken cancellationToken)
        {
            var personas = await _personaRepository.GetAll(); 
            return _mapper.Map<List<ListaPersona>>(personas);
        }
    }
}