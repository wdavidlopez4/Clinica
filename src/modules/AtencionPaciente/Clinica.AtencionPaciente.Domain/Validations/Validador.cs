using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Validations
{
    public class Validador
    {
        internal static bool Validar<T>(T obj, params Predicate<T>[] validaciones) =>
            validaciones.ToList().Where(x =>
            {
                return !x(obj);

            }).Count() == 0;

    }
}
