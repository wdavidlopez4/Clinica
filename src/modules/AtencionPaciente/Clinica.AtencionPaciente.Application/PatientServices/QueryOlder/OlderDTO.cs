﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientServices.QueryOlder
{
    public class OlderDTO
    {
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public string NumeroHistoriasClinico { get; set; }

        public double Prioridad { get; set; }

        public double Riesgo { get; set; }

        public bool TieneDieta { get; set; }
    }
}
