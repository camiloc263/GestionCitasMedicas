using MediatR;
using Persona.Application.Queries;
using Persona.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using AutoMapper;
using Persona.Application.DTO;

namespace Persona.Application.Commands
{
	public class UpdatePersonaByDocumentoCommandHandler 
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public UpdatePersonaByDocumentoCommandHandler(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        /*  public async Task<bool> Handle(UpdatePersonaByDocumentoQuery request, CancellationToken cancellationToken)
         {
            var persona = await _personaRepository.GetByDocumentoAsync(request.NumeroDocumento);
             if (persona == null) return false;

             // Actualizar los campos de la persona
             persona.nombre = request.Persona.nombre;
             persona.apellidoUno = request.Persona.apellidoUno;
             persona.apellidoDos = request.Persona.apellidoDos;
             persona.direccion = request.Persona.direccion;
             persona.telefono = request.Persona.telefono;
             persona.correo = request.Persona.correo;
             persona.fechaNacimiento = request.Persona.fechaNacimiento;
             persona.tipoUsuario = request.Persona.tipoUsuario;



             var resultado= await _personaRepository.UpdateAsync(persona.numeroDocumento,request.Persona);

             return true;
         }*/

    }
}