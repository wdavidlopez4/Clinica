using Clinica.AtencionPaciente.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public class Joven : Paciente
    {
        public bool EsFumador { get; private set; }

        public Joven(bool esFumador, string nombre, int edad, string numeroHistoriasClinico,
            string hospitalId, Guid? id = null) : base(nombre, edad, numeroHistoriasClinico, hospitalId, id)
        {
            this.EsFumador = esFumador;

            if (Validations.Validador.Validar<Joven>(this, JovenValidacion.validaciones) == false)
                throw new ArgumentException("datos incorrectos para crear el modelo ninno");
        }
    }
}
