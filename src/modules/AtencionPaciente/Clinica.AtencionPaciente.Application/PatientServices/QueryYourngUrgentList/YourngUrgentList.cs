using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientServices.QueryYourngUrgentList
{
    public class YourngUrgentList : IRequest<List<YourngUrgentListDTO>>
    {
        public string NumeroHistoriasClinico { get; set; }
    }
}
