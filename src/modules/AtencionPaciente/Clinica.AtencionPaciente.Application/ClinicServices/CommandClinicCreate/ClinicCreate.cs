using Clinica.AtencionPaciente.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.ClinicServices.CommandClinicCreate
{
    public class ClinicCreate : IRequest<ClinicCreateDTO>
    {
        public TipoConsultaEnum TipoConsulta { get; set; }

        public EstadoEnum Estado { get; set; }

        public string NombreEspecialista { get; set; }
    }
}
