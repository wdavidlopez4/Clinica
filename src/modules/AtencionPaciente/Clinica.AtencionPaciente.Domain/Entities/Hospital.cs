using Clinica.AtencionPaciente.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public class Hospital : Entity
    {
        public List<Paciente> Pacientes { get; private set; }

        public List<ConsultaClinica> ConsultasClinicas { get; private set; }


        internal Hospital(List<Paciente> pacientes, List<ConsultaClinica> consultasClinicas, Guid? id = null) : base(id)
        {
            this.Pacientes = pacientes;
            this.ConsultasClinicas = consultasClinicas;

            if (Validations.Validador.Validar<Hospital>(this, Hospitalvalidacion.validaciones) == false)
                throw new ArgumentException("datos incorrectos para crear el modelo hospital");
        }

        internal Hospital(Paciente paciente, ConsultaClinica consultasClinica, Guid? id = null) : base(id)
        {
            this.Pacientes.Add(paciente);
            this.ConsultasClinicas.Add(consultasClinica);

            if (Validations.Validador.Validar<Hospital>(this, Hospitalvalidacion.validaciones) == false)
                throw new ArgumentException("datos incorrectos para crear el modelo hospital");
        }

        internal Hospital(Guid? id = null) : base(id)
        {
            //cuando se cree por primera ves un hospital
        }

        private Hospital()
        {
            //for ef
        }

    }
}
