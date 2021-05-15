using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public class Especialista : Entity
    {
        public string Nombre { get; private set; }

        public ConsultaClinica ConsultaClinica { get; private set; }
    }
}
