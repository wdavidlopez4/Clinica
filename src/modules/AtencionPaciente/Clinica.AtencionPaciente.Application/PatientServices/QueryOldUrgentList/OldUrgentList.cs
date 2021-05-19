using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientServices.QueryOldUrgentList
{
    public class OldUrgentList : IRequest<List<OldUrgentListDTO>>
    {
        public string NumeroHistoriasClinico { get; set; }
    }
}
