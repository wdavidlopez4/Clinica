using Clinica.AtencionPaciente.Domain.Entities;
using Clinica.AtencionPaciente.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Application.PatientServices.QueryYoungUrgentSmokerslist
{
    public class YoungUrgentSmokerslistHandler : IRequestHandler<YoungUrgentSmokerslist, List<YoungUrgentSmokerslistDTO>>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public YoungUrgentSmokerslistHandler(IRepository repository, IAutoMapping autoMapping)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
        }

        public async Task<List<YoungUrgentSmokerslistDTO>> Handle(YoungUrgentSmokerslist request, CancellationToken cancellationToken)
        {
            var jovenes = await this.repository.GetAll<Joven>(
                x => x.Prioridad > 4 && x.EsFumador == true,
                x => x.Prioridad,
                cancellationToken);

            return this.autoMapping.Map<List<Joven>, List<YoungUrgentSmokerslistDTO>>(jovenes);
        }
    }
}
