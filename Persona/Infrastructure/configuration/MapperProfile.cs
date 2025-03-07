using AutoMapper;
using Persona.Application.DTO;
using Persona.Domain.Entities;




namespace Persona.Application
{
	public class MapperProfile: Profile
	{
        public MapperProfile()
        {
            // CreateMap<PersonasDto, ListaPersona>().ReverseMap().ForMember(dest => dest.numeroDocumento, opt => opt.Ignore());
            CreateMap<ListaPersona, PersonasDto>().ReverseMap();



        }
    }
}