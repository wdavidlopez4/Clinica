using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientServices.QueryOlder
{
    public class Older : IRequest<List<OlderDTO>>
    {
    }
}
