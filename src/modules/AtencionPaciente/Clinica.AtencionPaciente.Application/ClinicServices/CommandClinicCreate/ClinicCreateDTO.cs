using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.ClinicServices.CommandClinicCreate
{
    public class ClinicCreateDTO
    {
        public string Id { get; set; }

        public int CantidadPacientes { get; set; }

        public TipoConsultaEnum TipoConsulta { get; set; }

        public EstadoEnum Estado { get; set; }

        public class Especialista
        {
            public string Id { get; set; }

            public string Nombre { get; set; }
        }
    }
}
