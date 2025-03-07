using Persona.Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Persona.Application.DTO;
using System.Linq;
using Persona.Domain.Entities;
using System.Data.Entity;

namespace Persona.Infrastructure.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaContext _context;
        private readonly IPersonaRepository _personaRepository;
        public PersonaRepository(PersonaContext context) 
        {
            _context = context;
        }
        public async Task<List<ListaPersona>> GetAll()
        {
            return await  _context.ListaPersona.ToListAsync();
        }

        public async Task<ListaPersona> GetByDocumentoAsync(string numeroDocumento)
        {

              return await _personaRepository.GetByDocumentoAsync(numeroDocumento);

        }


        /*       public async Task<bool> UpdatePersonaByDocumento(string numeroDocumento, PersonasDto persona)
           {
                await _personaRepository.UpdateAsync(numeroDocumento, persona);

               return true;


           }




              public async Task<bool> AddPersona(PersonasDto nuevaPersona)
              {
                  return await _context.AddPersona(nuevaPersona);
              }

              public async Task<bool> DeletePersonaByDocumento(string numeroDocumento)
              {
                  return await _context.DeletePersonaByDocumento(numeroDocumento);
              }

              */

    }
}
