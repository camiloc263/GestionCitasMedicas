using CitasMedicas.Application.Services;
using CitasMedicas.Infrastructure.Repository;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CitasMedicas.Infrastructure.Controllers
{
    [RoutePrefix("api/citaMedica")]
    public class CitaMedicaController : ApiController
    {
        private readonly ICitaMedicaServices citaMedicaServices;
        private readonly PersonaClient personaClient;
        

        public CitaMedicaController(ICitaMedicaServices citaMedicaServices, PersonaClient personaClient)
        {
            this.citaMedicaServices = citaMedicaServices;
            this.personaClient = personaClient;

        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await citaMedicaServices.GetAll());
        }
        [HttpGet]
        [Route("{fecha}")]
        public async Task<IHttpActionResult> GetByDate(string fecha)
        {
            DateTime.TryParse(fecha, out DateTime fechaParsed);
           
            var citas = await citaMedicaServices.GetByDate(fechaParsed);

            if (citas == null || citas.Count == 0)
            {
                return NotFound();
            }

            return Ok(citas);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateCita([FromBody] CitaMedica cita)
        {
            
            var resultado = await citaMedicaServices.UpdateCita(cita);

            if (!resultado)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPut]
        [Route("{idPaciente}")]
        public async Task<IHttpActionResult> UpdateCitaByPacienteId(int idPaciente, [FromBody] CitaMedica cita)
        {
           

            var resultado = await citaMedicaServices.UpdateCitaByPacienteId(idPaciente, cita);

            if (!resultado)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddCita([FromBody] CitaMedica cita)
        {
           

            var nuevaCita = await citaMedicaServices.AddCita(cita);

            return Created($"api/CitaMedica/{nuevaCita.idcita}", nuevaCita);
        }

        [HttpDelete]
        [Route("{idcita}")]
        public async Task<IHttpActionResult> DeleteCita(int idcita)
        {
            var resultado = await citaMedicaServices.DeleteCita(idcita);

            if (!resultado)
                return NotFound();

            return Ok(resultado);
        }

        [HttpGet]
        [Route("{numeroDocumento}")]
        public async Task<IHttpActionResult> GetPersonaInfo(string numeroDocumento)
        {
            var persona = await personaClient.GetPersonaByDocumento(numeroDocumento);
            if (persona == null)
                return NotFound();

            return Ok(persona);
        }
        [HttpPut]
        [Route("finalizar/{idUsuario}")]
        public async Task<IHttpActionResult> FinalizarCitaAsync(int idUsuario, [FromBody] CitaMedica cita)
        {
            var resultado = await citaMedicaServices.FinalizarCitaAsync(idUsuario, cita);

            if (!resultado)
                return NotFound();

            return Ok("Cita finalizada exitosamente");
        }

    }
}
