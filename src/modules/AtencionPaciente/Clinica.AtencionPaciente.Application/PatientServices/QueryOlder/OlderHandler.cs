using Clinica.AtencionPaciente.Domain.Entities;
using Clinica.AtencionPaciente.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Application.PatientServices.QueryOlder
{
    public class OlderHandler : IRequestHandler<Older, List<OlderDTO>>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public OlderHandler(IRepository repository, IAutoMapping autoMapping)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
        }

        public async Task<List<OlderDTO>> Handle(Older request, CancellationToken cancellationToken)
        {
            var ancianos = await this.repository.GetAll<Anciano>(
                x => x.Prioridad >= 0,
                x => x.Edad,
                cancellationToken);

            return this.autoMapping.Map<List<Anciano>, List<OlderDTO>>(ancianos);
        }
    }
}
