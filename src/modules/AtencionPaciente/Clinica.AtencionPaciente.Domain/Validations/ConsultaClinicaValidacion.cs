using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Validations
{
    public class ConsultaClinicaValidacion
    {
        internal static readonly Predicate<ConsultaClinica>[] validaciones =
        {
            (x) => x.Id != null && x.Id != "",
            (x) => x.CantidadPacientes >=0,
            (x) => x.EspecialistaId != null && x.EspecialistaId != ""
        };
    }
}
