using AutoMapper;
using Persona.Application.DTO;
using Persona.Application.Services;
using Persona.Domain.Interface;
using Persona.Infrastructure.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace Persona.Application.Services
{
	public class PersonaServices: IPersonaServices
    {

        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;
      

        public PersonaServices(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository; 
            _mapper = mapper;
           

        }

        public async Task<List<PersonasDto>> GetAll()
        {

           return  _mapper.Map<List<PersonasDto>>(_personaRepository.GetAll());
    

        }

        public async Task<PersonasDto> GetByDocumentoAsync(string numeroDocumento)
        {
                         
              return _mapper.Map<PersonasDto>(_personaRepository.GetByDocumentoAsync(numeroDocumento));
        }

        /*  public async Task<bool> UpdatePersonaByDocumento(string numeroDocumento, PersonasDto personaDto)
          {
              var persona = await _personaServices.GetByDocumentoAsync(numeroDocumento);
              if (persona == null)
                  return false;

              var personaActualizada = _mapper.Map(personaDto, persona);
              return await _personaServices.UpdateAsync(numeroDocumento, personaDto);
          }


          /*  public async Task<List<PersonasDto>> GetByTipoUsuario(string tipoUsuario)
                    {
                        var personas = await _personaRepository.GetByTipoUsuario(tipoUsuario);
                        return _mapper.Map<List<PersonasDto>>(personas);
                    }



                    public async Task<bool> AddPersona(PersonasDto nuevaPersona)
                    {
                        return await _personaRepository.AddPersona(nuevaPersona);
                    }

                    public async Task<bool> DeletePersonaByDocumento(string numeroDocumento)
                    {
                        return await _personaRepository.DeletePersonaByDocumento(numeroDocumento);
                    }


                    */


    }
}