using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public abstract class Paciente : Entity
    {
        public string Nombre { get; protected set; }

        public int Edad { get; protected set; }

        public string NumeroHistoriasClinico { get; protected set; }

        public List<Hospital> Hospital { get; private set; }

        public double Prioridad { get; private set; }

        public double Riesgo { get; private set; }

        internal protected Paciente(string nombre, int edad, string numeroHistoriasClinico, 
            double prioridad, double riesgo, List<Hospital> hospital = null, Guid? id = null):base(id)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.NumeroHistoriasClinico = numeroHistoriasClinico;
            this.Prioridad = prioridad;
            this.Riesgo = riesgo;
            this.Hospital = hospital;
        }

        internal protected Paciente()
        {
            //for ef
        }

    }
}
