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

        public Hospital Hospital { get; private set; }

        public string HospitalId { get; private set; }

        public double Prioridad { get; private set; }

        public double Riesgo { get; private set; }

        internal protected Paciente(string nombre, int edad, string numeroHistoriasClinico, 
            string hospitalId, double prioridad, double riesgo, Guid? id = null):base(id)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.NumeroHistoriasClinico = numeroHistoriasClinico;
            this.HospitalId = hospitalId;
            this.Prioridad = prioridad;
            this.Riesgo = riesgo;
        }

        internal protected Paciente()
        {
            //for ef
        }

    }
}
