using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientServices.CommandOldCreate
{
    public class OldCreate : IRequest<OldCreateDTO>
    {
        public string Nombre { get; protected set; }

        public int Edad { get; protected set; }

        public string NumeroHistoriasClinico { get; protected set; }

        public string HospitalId { get; private set; }

        public bool TieneDieta { get; private set; }
    }
}
