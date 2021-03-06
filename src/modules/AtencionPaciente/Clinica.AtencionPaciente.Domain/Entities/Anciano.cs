using Clinica.AtencionPaciente.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public class Anciano : Paciente
    {
        public bool TieneDieta { get; private set; }

        internal Anciano(bool tieneDieta, string nombre, int edad, string numeroHistoriasClinico, double prioridad, double riesgo, List<Hospital> hospital = null, Guid ? id = null) 
            :base(nombre, edad, numeroHistoriasClinico, prioridad, riesgo, hospital, id)
        {
            this.TieneDieta = tieneDieta;

            if (Validations.Validador.Validar<Anciano>(this, AncianoValidacion.validaciones) == false)
                throw new ArgumentException("datos incorrectos para crear el modelo anciano");
        }

        private Anciano():base()
        {
            //for ef
        }
    }
}
