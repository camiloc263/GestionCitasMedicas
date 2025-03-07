using RecetasMedicas.Application.Services;
using RecetasMedicas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace RecetasMedicas.Infrastructure.Controllers
{
    [RoutePrefix("api/formulamedica")]
    public class FormulaMedicaController : ApiController
    {
        private readonly IFormulaMedicaServices formulaMedicaServices;

        public FormulaMedicaController(IFormulaMedicaServices formulaMedicaServices)
        {
            this.formulaMedicaServices = formulaMedicaServices;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IHttpActionResult> GetAll()
        {
            
            return Ok(await formulaMedicaServices.GetAllFormulasMedicas());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var formulaMedica = await formulaMedicaServices.GetById(id);
            if (formulaMedica == null)
            {
                return NotFound(); //Return 404 if not found
            }
            return Ok(formulaMedica);
        }

        [HttpGet]
        [Route("{codigoReceta}")]
        public async Task<IHttpActionResult> GetByCodigoReceta(string codigoReceta)
        {
            if (string.IsNullOrWhiteSpace(codigoReceta))
            {
                return BadRequest("El código de receta no puede estar vacío.");
            }

            var receta = await formulaMedicaServices.GetByCodigoRecetaAsync(codigoReceta);
            if (receta == null)
            {
                return NotFound();
            }

            return Ok(receta);
        }
        [HttpPut]
        [Route("{codigoReceta}")]
        public async Task<IHttpActionResult> UpdateByCodigoReceta(string codigoReceta, [FromBody] FormulaMedica updatedFormula)
        {
            if (codigoReceta != updatedFormula.CodigoReceta)
            {
                return BadRequest("El 'codigoReceta' en la URL debe coincidir con el del cuerpo de la solicitud.");
            }

            var updated = await formulaMedicaServices.UpdateByCodigoRecetaAsync(codigoReceta, updatedFormula);
            if (!updated)
            {
                return NotFound();
                
            }

            return Ok("Persona actualizada correctamente");
        }
        [HttpPost]
        [Route("agregar")]
        public async Task<IHttpActionResult> AddFormulaMedica([FromBody] FormulaMedica formulaMedica)
        {
            if (formulaMedica == null)
            {
                return BadRequest("La receta médica es inválida.");
            }

            var creada = await formulaMedicaServices.AddFormulaMedicaAsync(formulaMedica);

            if (!creada)
            {
                return Content(HttpStatusCode.InternalServerError, "Error al guardar la receta médica.");
            }

            return Created($"api/formulamedica/codigo/{formulaMedica.CodigoReceta}", formulaMedica);
        }

        [HttpDelete]
        [Route("{codigoReceta}")]
        public async Task<IHttpActionResult> DeleteByCodigoReceta(string codigoReceta)
        {
            if (string.IsNullOrWhiteSpace(codigoReceta))
            {
                return BadRequest("El código de receta no puede estar vacío.");
            }

            var deleted = await formulaMedicaServices.DeleteByCodigoRecetaAsync(codigoReceta);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok("Receta médica eliminada correctamente.");
        }


    }
}