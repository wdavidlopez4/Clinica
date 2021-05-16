using Clinica.AtencionPaciente.Application.hospitalService.CommandHospitalCreateOne;
using Clinica.WebApi.Filters;
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
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class HospitalController : ControllerBase
    {
        private readonly IMediator mediator;

        public HospitalController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Hospital")]
        public async Task<IActionResult> RegistrarNinno([FromBody] HospitalCreateOne hospitalCreateOne)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            var dto = await this.mediator.Send(hospitalCreateOne);

            if (dto == null)
                return BadRequest("no se pudo registrar el hospital.");
            else
                return Ok(dto);
        }
    }
}
