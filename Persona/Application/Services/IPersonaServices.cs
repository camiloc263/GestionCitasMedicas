
using Persona.Application.DTO;
using Persona.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Application.Services
{
   public  interface IPersonaServices
    {
        Task<List<PersonasDto>> GetAll();
       // Task<PersonasDto> GetByDocumentoAsync(string numeroDocumento);
      //  Task<bool> UpdateAsync(string numeroDocumento, PersonasDto persona);
        /* Task<List<PersonasDto>> GetByTipoUsuario(string tipoUsuario);

         Task<bool> AddPersona(PersonasDto nuevaPersona);
         Task<bool> DeletePersonaByDocumento(string numeroDocumento);

         */
    }
}
