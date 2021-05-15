using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Validations
{
    public class Hospitalvalidacion
    {
        internal static readonly Predicate<Hospital>[] validaciones =
        {
            (x) => x.Id != null && x.Id != "",
            (x) => x.Pacientes != null && x.Pacientes.Count > 0,
            (x) => x.ConsultasClinicas != null && x.ConsultasClinicas.Count > 0
        };

    }
}
