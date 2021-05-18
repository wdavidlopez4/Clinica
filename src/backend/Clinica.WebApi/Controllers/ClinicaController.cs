﻿using Clinica.AtencionPaciente.Application.ClinicServices.CommandClinicCreate;
using Clinica.AtencionPaciente.Application.PatientServices.QueyBoyUrgentlist;
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
    [TypeFilter(typeof(ExceptionManagerFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClinicaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Consulta")]
        public async Task<IActionResult> RegistrarConsultaClinica([FromBody] ClinicCreate boyCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            var dto = await this.mediator.Send(boyCreate);

            if (dto == null)
                return BadRequest("no se pudo registrar el joven.");
            else
                return Ok(dto);
        }

        [HttpPost]
        [Route("NinnosUrgentes")]
        public async Task<IActionResult> ObtenerNinnosUrgentes([FromBody] BoyUrgentlist boyUrgentlist)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo no es valido, ingrese correctamente los datos.");

            var dto = await this.mediator.Send(boyUrgentlist);

            if (dto == null)
                return BadRequest("no se pudo registrar el joven.");
            else
                return Ok(dto);
        }
    }
}
