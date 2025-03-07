using MediatR;
using Persona.Application.Commands;
using Persona.Application.DTO;
using Persona.Application.Queries;
using Persona.Application.Services;
using Persona.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Persona.Infrastructure.Controllers
{
    [RoutePrefix("api/persona")]
    public class PersonaController : ApiController
    {
        private readonly IMediator _mediator;
        public PersonaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route]
        public async Task<IHttpActionResult> GetAll()
        {
            var personas = await _mediator.Send(new GetAllPersonasQuery());
            return Ok(personas);
        }

        [HttpGet]
        [Route("{numeroDocumento}")]
        public async Task<IHttpActionResult> GetByDocumento(string numeroDocumento)
        {
            var persona = await _mediator.Send(new GetPersonaByDocumentoQuery(numeroDocumento));

            if (persona == null)
                return NotFound();

            return Ok(persona);
        }


    }
}
