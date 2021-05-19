using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientServices.QueyBoyUrgentlist
{
    public class BoyUrgentlist : IRequest<List<BoyUrgentlistDTO>>
    {
        public string NumeroHistoriasClinico { get; set; }
    }
}
