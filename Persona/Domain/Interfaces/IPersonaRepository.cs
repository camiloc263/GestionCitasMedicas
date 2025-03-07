using Persona.Application.DTO;
using Persona.Domain.Entities;
using Persona.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Domain.Interface
{
   public interface IPersonaRepository
    {
        Task<List<ListaPersona>> GetAll();
        Task<ListaPersona> GetByDocumentoAsync(string numeroDocumento);
        //Task<bool> UpdateAsync(string numeroDocumento, PersonasDto persona);
        /* Task<List<PersonasDto>> GetByTipoUsuario(string tipoUsuario);
         Task<bool> AddPersona(PersonasDto nuevaPersona);
         Task<bool> DeletePersonaByDocumento(string numeroDocumento);
         ;
         */

    }
}
