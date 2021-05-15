using Clinica.AtencionPaciente.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public class Especialista : Entity
    {
        public string Nombre { get; private set; }

        public ConsultaClinica ConsultaClinica { get; private set; }

        internal Especialista(string nombre, Guid? id = null):base(id)
        {
            this.Nombre = nombre;

            if (Validations.Validador.Validar<Especialista>(this, EspecialistaValidacion.validaciones) == false)
                throw new ArgumentException("datos incorrectos para crear el modelo hospital");
        }

        private Especialista()
        {
            //for ef
        }
    }
}
