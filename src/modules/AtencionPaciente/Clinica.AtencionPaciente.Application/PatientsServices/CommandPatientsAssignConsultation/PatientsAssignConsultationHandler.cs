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

        public PatientsAssignConsultationHandler(IFactory factory, IRepository repository)
        {
            this.factory = factory;
            this.repository = repository;
        }

        public async Task<PatientsAssignConsultationDTO> Handle(PatientsAssignConsultation request,
            CancellationToken cancellationToken)
        {
            return null;
        }

        

    }
}
