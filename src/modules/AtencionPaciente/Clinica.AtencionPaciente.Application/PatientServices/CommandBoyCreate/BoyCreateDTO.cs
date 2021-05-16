﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientServices.CommandBoyCreate
{
    public class BoyCreateDTO
    {
        public string Nombre { get; protected set; }

        public int Edad { get; protected set; }

        public string NumeroHistoriasClinico { get; protected set; }

        public string HospitalId { get; private set; }

        public double Prioridad { get; private set; }

        public double Riesgo { get; private set; }

        public int RelacionPesoEstatura { get; private set; }
    }
}