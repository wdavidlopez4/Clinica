using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientsServices.CommandPatientsAssignConsultation
{
    public class PatientsAssignConsultationDTO
    {
        public bool noFaltanNiññosPediatria { get; set; }

        public bool noFaltanNiññosUregncias { get; set; }

        public bool noFaltanJovensGeneral { get; set; }

        public bool noFaltanJovensUrgencias { get; set; }

        public bool noFaltanAncianosGeneral { get; set; }

        public bool noFaltanAncianosUrgencias { get; set; }
    }
}
