using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Validations
{
    public class NinnoValidacion
    {
        internal static readonly Predicate<Ninno>[] validaciones =
        {
            (x) => x.Id != null && x.Id != "",
            (x) => x.Nombre != null && x.Nombre != "",
            (x) => x.NumeroHistoriasClinico.Length == 15 && x.NumeroHistoriasClinico != "" && x.NumeroHistoriasClinico != null,
            (x) => x.Edad <= 150 && x.Edad >= 0,
            (x) => x.Prioridad >=0,
            (x) => x.Riesgo >= 0,
            (x) => x.RelacionPesoEstatura <= 4 && x.RelacionPesoEstatura >= 0
        };
    }
}
