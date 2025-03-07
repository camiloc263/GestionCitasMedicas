using CitasMedicas.Domain.Interfaces;
using CitasMedicas.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CitasMedicas.Infrastructure.Repository
{
	public class CitaMedicaRepository: ICitaMedicaRepository
	{
        private readonly RabbitMQProduce rabbitMQProduce;
		private readonly CitaMedicaContext _context;
        
		public CitaMedicaRepository(CitaMedicaContext context, RabbitMQProduce rabbitMQProduce )
		{
			this._context = context;
            this.rabbitMQProduce = rabbitMQProduce;
		}
		public async Task<List<CitaMedica>> GetAll()
		{
			return await _context.citamedica.ToListAsync();
		}

        public async Task<List<CitaMedica>> GetByDate(DateTime fecha)
        {
            return await _context.citamedica
                .Where(c => DbFunctions.TruncateTime(c.fechacita) == fecha.Date)
                .ToListAsync();
        }
        public async Task<CitaMedica> GetByPersonaId(int idpaciente)
        {
            return await _context.citamedica.FirstOrDefaultAsync(c => c.idpaciente == idpaciente);
        }

        public async Task<bool> Update(CitaMedica cita)
        {
            var citaExistente = await _context.citamedica.FindAsync(cita.idcita);
            if (citaExistente == null)
                return false;

            citaExistente.idpaciente = cita.idpaciente ?? citaExistente.idpaciente;
            citaExistente.idmedico = cita.idmedico ?? citaExistente.idmedico;
            citaExistente.lugarcita = cita.lugarcita ?? citaExistente.lugarcita;
            citaExistente.fechacita = cita.fechacita ?? citaExistente.fechacita;
            citaExistente.estadocita = cita.estadocita ?? citaExistente.estadocita;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCitaByPacienteId(int idPaciente, CitaMedica cita)
        {
            var citaExistente = await _context.citamedica
                .FirstOrDefaultAsync(c => c.idpaciente == idPaciente);

            if (citaExistente == null)
                return false; // No se encontró la cita para el paciente

            // Actualizar los campos si el valor no es nulo
            citaExistente.idmedico = cita.idmedico ?? citaExistente.idmedico;
            citaExistente.lugarcita = cita.lugarcita ?? citaExistente.lugarcita;
            citaExistente.fechacita = cita.fechacita ?? citaExistente.fechacita;
            citaExistente.estadocita = cita.estadocita ?? citaExistente.estadocita;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CitaMedica> AddCita(CitaMedica cita)
        {
            
            _context.citamedica.Add(cita);
            await _context.SaveChangesAsync();
            return cita;
        }
        public async Task<bool> DeleteCita(int idcita)
        {
            var cita = await _context.citamedica.FindAsync(idcita);
            if (cita == null)
                return false;

            _context.citamedica.Remove(cita);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ValidarExistenciaPersona(int idpaciente)
        {
            return await _context.citamedica.AnyAsync(c => c.idpaciente == idpaciente);
        }

        public async Task<bool> FinalizarCitaAsync(int idPaciente, CitaMedica cita)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {
                    var citaMedica = await _context.citamedica
                        .FirstOrDefaultAsync(c => c.idpaciente == idPaciente);

                    if (citaMedica == null)
                        return false;

                    citaMedica.estadocita = "Finalizada";
                    await _context.SaveChangesAsync();

                    var receta = new
                    {
                        CodigoReceta = cita.codigoReceta,
                        IdPaciente = cita.idpaciente,
                        FechaEmision = cita.FechaEmision,
                        FechaVencimiento = cita.fechaVencimiento, 
                        Estado = cita.estado,
                        Descripcion = cita.descripcion
                    };

                    await rabbitMQProduce.PublicarMensaje(receta);

                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                  
                    Console.WriteLine($"Error en FinalizarCitaAsync: {e.Message}");
                    throw;
                }
            }

           
        }


    }
}