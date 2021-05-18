using Clinica.AtencionPaciente.Application.PatientsServices.CommandPatientsAssignConsultation;
using Clinica.AtencionPaciente.Domain.Entities;
using Clinica.AtencionPaciente.Domain.Factories;
using Clinica.AtencionPaciente.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Application.PatientsServices.CommandPatientsToAssignConsultation
{
    public class PatientsAssignConsultationHandler 
        : IRequestHandler<PatientsAssignConsultation, PatientsAssignConsultationDTO>
    {
        private readonly IFactory factory;

        private readonly IRepository repository;

        private List<Ninno> ninnosAPediatria;

        private List<Ninno> ninnosAUrgencias;

        private List<Joven> jovenesAUrgencias;

        private List<Joven> jovenesAGeneral;

        private List<Anciano> ancianosAUrgencias;

        private List<Anciano> ancianosAGeneral;

        private bool asignadoPediatria;

        private bool asignadoUrgencias;

        private bool asignadoGeneral;

        public PatientsAssignConsultationHandler(IFactory factory, IRepository repository)
        {
            this.factory = factory;
            this.repository = repository;
        }

        public async Task<PatientsAssignConsultationDTO> Handle(PatientsAssignConsultation request, 
            CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("peticion nula para los asignamientos");

            List<Paciente> pacientes;
            Hospital hospital;

            await ClasificacionPacientesAConsultorioClinico(cancellationToken);

            //si no hay consultas disponibles enviamos los pacientes a sala de espera y claro sin consultas clinicas
            if (this.repository.Exists<ConsultaClinica>(x => x.Estado == EstadoEnum.Desocupado) == false)
            {
                pacientes = new List<Paciente>();
                pacientes.AddRange(ninnosAPediatria);
                pacientes.AddRange(ninnosAUrgencias);
                pacientes.AddRange(jovenesAUrgencias);
                pacientes.AddRange(jovenesAGeneral);
                pacientes.AddRange(ancianosAUrgencias);
                pacientes.AddRange(ancianosAGeneral);

                hospital = (Hospital) this.factory.CreateHospital(
                    sala: SalaEnum.Espera, 
                    pacientes: pacientes, 
                    consultasClinicas: null);

                hospital = await this.repository.Save<Hospital>(hospital, cancellationToken);

                asignadoPediatria = false;
                asignadoUrgencias = false;
                asignadoGeneral = false;
            }
            else
            {
                //procesamiento para asignar los pacientes que van a urgencias, pediatria...
                await AsignarPacientesEnUrgencias(cancellationToken);
                await AsignarPacientesEnPediatria(cancellationToken);
                await AsignarPacientesAGeneral(cancellationToken);
            }

            return new PatientsAssignConsultationDTO
            {
                AsignadoGeneral = asignadoGeneral,
                AsignadoPediatria = asignadoPediatria,
                AsignadoUrgencias = asignadoUrgencias
            };

        }

        private async Task ClasificacionPacientesAConsultorioClinico(CancellationToken cancellationToken)
        {
            //recuperar los pacientes para las asignacioes a las consultas clinicas
            this.ninnosAPediatria = await this.repository.GetAll<Ninno>(x => x.Prioridad <= 4, cancellationToken);
            this.ninnosAUrgencias = await this.repository.GetAll<Ninno>(x => x.Prioridad > 4, cancellationToken);

            this.jovenesAUrgencias = await this.repository.GetAll<Joven>(x => x.Prioridad > 4, cancellationToken);
            this.jovenesAGeneral = await this.repository.GetAll<Joven>(x => x.Prioridad < 4, cancellationToken);

            this.ancianosAUrgencias = await this.repository.GetAll<Anciano>(x => x.Prioridad > 4, cancellationToken);
            this.ancianosAGeneral = await this.repository.GetAll<Anciano>(x => x.Prioridad < 4, cancellationToken);
        }

        private async Task AsignarPacientesEnUrgencias(CancellationToken cancellationToken)
        {
            List<Paciente> pacientes;
            Hospital hospital;

            //recuperar consultas clinicas desocupasas y con urgencia
            var consultasClinicasDisponiblesUrgentes = await this.repository.GetAll<ConsultaClinica>(
                expression: x => x.Estado == EstadoEnum.Desocupado && x.TipoConsulta == TipoConsultaEnum.Urgencias,
                cancellationToken: cancellationToken);

            //agrupar urgentes
            pacientes = new List<Paciente>();
            pacientes.AddRange(this.ninnosAUrgencias);
            pacientes.AddRange(this.jovenesAUrgencias);
            pacientes.AddRange(this.ancianosAUrgencias);

            if (consultasClinicasDisponiblesUrgentes.Count > 0)
            {
                hospital = (Hospital)this.factory.CreateHospital(
                    sala: SalaEnum.Espera,
                    pacientes: pacientes,
                    consultasClinicas: consultasClinicasDisponiblesUrgentes);

                this.asignadoUrgencias = true;
            }
            else
            {
                hospital = (Hospital)this.factory.CreateHospital(
                    sala: SalaEnum.pendiente,
                    pacientes: pacientes,
                    consultasClinicas: null);

                asignadoUrgencias = false;
            }

            hospital = await this.repository.Save<Hospital>(hospital, cancellationToken);
        }

        private async Task AsignarPacientesEnPediatria(CancellationToken cancellationToken)
        {
            List<Paciente> pacientes;
            Hospital hospital;

            //recuperar consultas clinicas desocupasas y con urgencia
            var consultasClinicasDisponiblesPediatria = await this.repository.GetAll<ConsultaClinica>(
                expression: x => x.Estado == EstadoEnum.Desocupado && x.TipoConsulta == TipoConsultaEnum.Pediatria,
                cancellationToken: cancellationToken);

            //agrupar en pedriatria
            pacientes = new List<Paciente>();
            pacientes.AddRange(this.ninnosAPediatria);

            if (consultasClinicasDisponiblesPediatria.Count > 0)
            {
                hospital = (Hospital)this.factory.CreateHospital(
                    sala: SalaEnum.Espera,
                    pacientes: pacientes,
                    consultasClinicas: consultasClinicasDisponiblesPediatria);

                this.asignadoPediatria = true;
            }
            else
            {
                hospital = (Hospital)this.factory.CreateHospital(
                    sala: SalaEnum.pendiente,
                    pacientes: pacientes,
                    consultasClinicas: null);

                this.asignadoPediatria = false;
            }

            hospital = await this.repository.Save<Hospital>(hospital, cancellationToken);
        }

        private async Task AsignarPacientesAGeneral(CancellationToken cancellationToken)
        {
            List<Paciente> pacientes;
            Hospital hospital;

            //recuperar consultas clinicas desocupasas y con urgencia
            var consultasClinicasDisponiblesGeneral = await this.repository.GetAll<ConsultaClinica>(
                expression: x => x.Estado == EstadoEnum.Desocupado && x.TipoConsulta == TipoConsultaEnum.MedicinaGeneral,
                cancellationToken: cancellationToken);

            //agrupar generales
            pacientes = new List<Paciente>();
            pacientes.AddRange(this.jovenesAGeneral);
            pacientes.AddRange(this.jovenesAGeneral);

            if (consultasClinicasDisponiblesGeneral.Count > 0)
            {
                hospital = (Hospital)this.factory.CreateHospital(
                    sala: SalaEnum.Espera,
                    pacientes: pacientes,
                    consultasClinicas: consultasClinicasDisponiblesGeneral);

                this.asignadoGeneral = true;
            }
            else
            {
                hospital = (Hospital)this.factory.CreateHospital(
                    sala: SalaEnum.pendiente,
                    pacientes: pacientes,
                    consultasClinicas: null);

                this.asignadoGeneral = false;
            }

            hospital = await this.repository.Save<Hospital>(hospital, cancellationToken);
        }

    }
}
