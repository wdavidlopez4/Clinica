using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.PatientsServices.CommandPatientsAssignConsultation
{
    public class PatientsAssignConsultationDTO
    {
        public bool AsignadoUrgencias { get; set; }

        public bool AsignadoPediatria { get; set; }

        public bool AsignadoGeneral { get; set; }
    }
}
