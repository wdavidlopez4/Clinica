using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientServices.CommandYoungCreate
{
    public class YoungCreateDTO
    {
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public string NumeroHistoriasClinico { get; set; }

        public string HospitalId { get; set; }

        public double Prioridad { get; set; }

        public double Riesgo { get; set; }

        public bool EsFumador { get; set; }

        public int AnnosFumando { get; set; }
    }
}
