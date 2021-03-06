using Clinica.AtencionPaciente.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public class ConsultaClinica : Entity
    {
        public int CantidadPacientes { get; private set; }

        public TipoConsultaEnum TipoConsulta { get; private set; }

        public EstadoEnum Estado { get; private set; }

        public Especialista Especialista { get; private set; }

        public string EspecialistaId { get; private set; }

        public List<Hospital> hospital { get; private set; }

        internal ConsultaClinica(int cantidadPacientes, TipoConsultaEnum tipoConsulta, EstadoEnum estado,
            string especialistaId, List<Hospital> hospital = null, Guid? id = null) : base(id)
        {
            this.CantidadPacientes = cantidadPacientes;
            this.TipoConsulta = tipoConsulta;
            this.Estado = estado;
            this.EspecialistaId = especialistaId;
            this.hospital = hospital;

            if (Validations.Validador.Validar<ConsultaClinica>(this, ConsultaClinicaValidacion.validaciones) == false)
                throw new ArgumentException("los datos para crear el modelo de consulta clinica son invalidos");
        }

        private ConsultaClinica():base()
        {
            //for ef
        }

    }
}
