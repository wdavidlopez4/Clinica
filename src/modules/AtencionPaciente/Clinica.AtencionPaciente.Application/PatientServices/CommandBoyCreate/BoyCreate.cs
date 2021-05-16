using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientServices.CommandBoyCreate
{
    public class BoyCreate : IRequest<BoyCreateDTO>
    {
        public string Nombre { get; protected set; }

        public int Edad { get; protected set; }

        public string NumeroHistoriasClinico { get; protected set; }

        public int RelacionPesoEstatura { get; private set; }

        public string HospitalId { get; private set; }
    }
}
