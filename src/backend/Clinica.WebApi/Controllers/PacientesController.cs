using Clinica.AtencionPaciente.Application.PatientServices.CommandBoyCreate;
using Clinica.AtencionPaciente.Application.PatientServices.CommandOldCreate;
using Clinica.AtencionPaciente.Application.PatientServices.CommandYoungCreate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IMediator mediator;

        public PacientesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Ninno")]
        public async Task<IActionResult> RegistrarNinno([FromBody] BoyCreate boyCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            var dto = await this.mediator.Send(boyCreate);

            if (dto == null)
                return BadRequest("no se pudo registrar el ninno.");
            else
                return Ok(dto);
        }

        [HttpPost]
        [Route("Joven")]
        public async Task<IActionResult> RegistrarJoven([FromBody] YoungCreate youngCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            var dto = await this.mediator.Send(youngCreate);

            if (dto == null)
                return BadRequest("no se pudo registrar el ninno.");
            else
                return Ok(dto);
        }

        [HttpPost]
        [Route("Anciano")]
        public async Task<IActionResult> RegistrarAnciano([FromBody] OldCreate oldCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            var dto = await this.mediator.Send(oldCreate);

            if (dto == null)
                return BadRequest("no se pudo registrar el ninno.");
            else
                return Ok(dto);
        }
    }
}
