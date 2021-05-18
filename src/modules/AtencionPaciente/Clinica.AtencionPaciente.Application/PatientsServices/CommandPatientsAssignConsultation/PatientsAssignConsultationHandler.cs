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

        private readonly IAutoMapping autoMapping;

        public PatientsAssignConsultationHandler(IFactory factory, IRepository repository, IAutoMapping autoMapping)
        {
            this.autoMapping = autoMapping;
            this.factory = factory;
            this.repository = repository;
        }

        public async Task<PatientsAssignConsultationDTO> Handle(PatientsAssignConsultation request, 
            CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("peticion nula para los asignamientos");

            //recuperar los pacientes para las asignacioes a las consultas clinicas
            var ninnosAPediatria = await this.repository.GetAll<Ninno>(x => x.Prioridad <= 4, cancellationToken);
            var ninnosAUrgencias = await this.repository.GetAll<Ninno>(x => x.Prioridad > 4, cancellationToken);

            var jovenesAUrgencias = await this.repository.GetAll<Joven>(x => x.Prioridad > 4, cancellationToken);
            var jovenesAGeneral = await this.repository.GetAll<Joven>(x => x.Prioridad < 4, cancellationToken);

            var ancianosAUrgencias = await this.repository.GetAll<Anciano>(x => x.Prioridad > 4, cancellationToken);
            var ancianosAGeneral = await this.repository.GetAll<Anciano>(x => x.Prioridad < 4, cancellationToken);

            //resuperar consultas clinicas desocupasas
            var consultasMedicasDisponibles = await this.repository.GetAll<ConsultaClinica>(
                expression: x => x.Estado == EstadoEnum.Desocupado,
                cancellationToken: cancellationToken);

            //if(consultasMedicasDisponibles == null)

            return null;
        }
    }
}
