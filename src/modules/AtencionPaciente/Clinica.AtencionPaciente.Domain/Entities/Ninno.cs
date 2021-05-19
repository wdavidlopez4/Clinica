using Clinica.AtencionPaciente.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public class Ninno : Paciente
    {
        public int RelacionPesoEstatura { get; private set; }

        internal Ninno(int relacionPesoEstatura, string nombre, int edad, string numeroHistoriasClinico, 
            double prioridad, double riesgo, List<Hospital> hospital = null, Guid ? id = null)
            : base(nombre, edad, numeroHistoriasClinico, prioridad, riesgo, hospital, id)
        {
            this.RelacionPesoEstatura = relacionPesoEstatura;

            if (Validations.Validador.Validar<Ninno>(this, NinnoValidacion.validaciones) == false)
                throw new ArgumentException("datos incorrectos para crear el modelo ninno");
        }

        private Ninno()
        {
            //ef
        }
    }
}
