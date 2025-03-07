using CitasMedicas.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitasMedicas.Domain.Interfaces
{
    public interface ICitaMedicaRepository
    {
         Task<List<CitaMedica>> GetAll();
         Task<List<CitaMedica>> GetByDate(DateTime fecha);
         Task<CitaMedica> GetByPersonaId(int personaId);
         Task<bool> Update(CitaMedica cita);
         Task<bool> UpdateCitaByPacienteId(int idPaciente, CitaMedica cita);
         Task<CitaMedica> AddCita(CitaMedica cita);
         Task<bool> DeleteCita(int idcita);
         Task<bool> ValidarExistenciaPersona(int idpaciente);
         Task<bool> FinalizarCitaAsync(int iduausuario, CitaMedica cita);



    }
}
