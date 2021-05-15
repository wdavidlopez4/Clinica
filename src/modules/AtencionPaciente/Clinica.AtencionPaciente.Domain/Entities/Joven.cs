using Clinica.AtencionPaciente.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public class Joven : Paciente
    {
        public bool EsFumador { get; private set; }

        public int AnnosFumando { get; private set; }

        public Joven(int annosFumando, bool esFumador, string nombre, int edad, string numeroHistoriasClinico,
            string hospitalId, double prioridad, double riesgo, Guid? id = null) 
            : base(nombre, edad, numeroHistoriasClinico, hospitalId, prioridad, riesgo, id)
        {
            this.EsFumador = esFumador;
            this.AnnosFumando = annosFumando;

            if (Validations.Validador.Validar<Joven>(this, JovenValidacion.validaciones) == false)
                throw new ArgumentException("datos incorrectos para crear el modelo ninno");
        }
    }
}
