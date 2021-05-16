using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientServices.CommandYoungCreate
{
    public class YoungCreateDTO
    {
        public string Nombre { get; protected set; }

        public int Edad { get; protected set; }

        public string NumeroHistoriasClinico { get; protected set; }

        public string HospitalId { get; private set; }

        public double Prioridad { get; private set; }

        public double Riesgo { get; private set; }

        public bool EsFumador { get; private set; }

        public int AnnosFumando { get; private set; }
    }
}
