using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientServices.CommandBoyCreate
{
    public class BoyCreate : IRequest<BoyCreateDTO>
    {
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public string NumeroHistoriasClinico { get; set; }

        public int RelacionPesoEstatura { get; set; }

        public string HospitalId { get; set; }
    }
}
