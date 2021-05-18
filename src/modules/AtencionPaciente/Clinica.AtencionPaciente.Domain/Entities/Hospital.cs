using Clinica.AtencionPaciente.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public class Hospital : Entity
    {
        public Paciente Pacientes { get; private set; }

        public ConsultaClinica ConsultasClinicas { get; private set; }

        public string PacientesId { get; private set; }

        public string ConsultasClinicasId { get; private set; }

        public SalaEnum Sala { get; private set; }

        public Hospital(string pacientesId, string consultasClinicasId, SalaEnum sala, Guid? id = null):base(id)
        {
            this.ConsultasClinicasId = consultasClinicasId;
            this.PacientesId = pacientesId;
            this.Sala = sala;

            if (Validations.Validador.Validar<Hospital>(this, Hospitalvalidacion.validaciones) == false)
                throw new ArgumentException("los datos para crear el modelo de consulta clinica son invalidos");
        }

        private Hospital()
        {
            //for ef
        }

    }
}
