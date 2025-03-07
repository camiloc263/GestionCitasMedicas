using CitasMedicas.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitasMedicas.Application.Services
{
   public interface ICitaMedicaServices
    {
        Task<List<CitaMedica>> GetAll();
        Task<List<CitaMedica>> GetByDate(DateTime fecha);
        Task<bool> UpdateCita(CitaMedica cita);
        Task<bool> UpdateCitaByPacienteId(int idPaciente, CitaMedica cita);
        Task<CitaMedica> AddCita(CitaMedica cita);
        Task<bool> DeleteCita(int idcita);
        Task <bool>FinalizarCitaAsync(int iduausuario, CitaMedica cita);


    }
}
