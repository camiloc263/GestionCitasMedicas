using CitasMedicas.Domain.Interfaces;
using CitasMedicas.Infrastructure.Messaging;
using CitasMedicas.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CitasMedicas.Application.Services
{
	public class CitaMedicaServices : ICitaMedicaServices
	{
        private readonly ICitaMedicaRepository citaMedicaRepository;
        private readonly PersonaClient personaClient;
        private readonly RabbitMQProduce rabbitMQProducer;

        public CitaMedicaServices(ICitaMedicaRepository citaMedicaRepository, PersonaClient personaClient, RabbitMQProduce rabbitMQProducer)
        {
            this.citaMedicaRepository = citaMedicaRepository;
            this.personaClient = personaClient;
            this.rabbitMQProducer = rabbitMQProducer;
        }
        public async Task<List<CitaMedica>> GetAll()
        {
            return await citaMedicaRepository.GetAll();
        }

        public async Task<List<CitaMedica>> GetByDate(DateTime fecha)
        {
            return await citaMedicaRepository.GetByDate(fecha);
        }

        public async Task<bool> UpdateCita(CitaMedica cita)
        {
           return await citaMedicaRepository.Update(cita);
        }

        public async Task<bool> UpdateCitaByPacienteId(int idPaciente, CitaMedica cita)
        {
            return await citaMedicaRepository.UpdateCitaByPacienteId(idPaciente, cita);
        }
        public async Task<CitaMedica> AddCita(CitaMedica cita)
        {
              return await citaMedicaRepository.AddCita(cita);
        }
        public async Task<bool> DeleteCita(int idcita)
        {
            return await citaMedicaRepository.DeleteCita(idcita);
        }

        public async Task<CitaMedica> AgendarCita(string numeroDocumento, DateTime fecha)
        {
            
            var persona = await personaClient.GetPersonaByDocumento(numeroDocumento);
            
           
            var nuevaCita = new CitaMedica
            {
                idpaciente = persona.idpaciente, 
                lugarcita = "Consultorio 1", 
                fechacita = fecha,
                estadocita = "Pendiente"
            };

           
            await citaMedicaRepository.AddCita(nuevaCita);
            return nuevaCita;
        }

        public async Task<bool> FinalizarCitaAsync(int idUsiario, CitaMedica cita)
        {
            return await citaMedicaRepository.FinalizarCitaAsync(idUsiario, cita);
        }
      }
}