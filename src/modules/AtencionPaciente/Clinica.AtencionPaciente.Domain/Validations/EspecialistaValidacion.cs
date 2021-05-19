using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Validations
{
    public class EspecialistaValidacion
    {
        internal static readonly Predicate<Especialista>[] validaciones =
        {
            (x) => x.Id != null && x.Id != "",
            (x) => x.Nombre != null && x.Nombre != ""
        };
    }
}
