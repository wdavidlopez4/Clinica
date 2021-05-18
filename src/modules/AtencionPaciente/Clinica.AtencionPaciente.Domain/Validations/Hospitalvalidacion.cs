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
        };

    }
}
