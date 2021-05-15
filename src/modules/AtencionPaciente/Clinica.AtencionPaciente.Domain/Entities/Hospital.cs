using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public class Hospital : Entity
    {
        public List<Paciente> Pacientes { get; private set; }
    }
}
