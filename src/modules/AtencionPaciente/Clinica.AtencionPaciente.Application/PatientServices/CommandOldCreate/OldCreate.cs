using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientServices.CommandOldCreate
{
    public class OldCreate : IRequest<OldCreateDTO>
    {
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public string NumeroHistoriasClinico { get; set; }

        public bool TieneDieta { get; set; }
    }
}
