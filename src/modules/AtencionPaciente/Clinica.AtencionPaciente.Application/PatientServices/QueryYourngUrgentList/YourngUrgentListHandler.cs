using Clinica.AtencionPaciente.Domain.Entities;
using Clinica.AtencionPaciente.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Application.PatientServices.QueryYourngUrgentList
{
    public class YourngUrgentListHandler : IRequestHandler<YourngUrgentList, List<YourngUrgentListDTO>>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public YourngUrgentListHandler(IRepository repository, IAutoMapping autoMapping)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
        }

        public async Task<List<YourngUrgentListDTO>> Handle(YourngUrgentList request, CancellationToken cancellationToken)
        {
            var jovenMayores = new List<Joven>();

            //obtener joveb para comparacion
            var jovenComparacion = await this.repository.Get<Joven>(
                x => x.NumeroHistoriasClinico == request.NumeroHistoriasClinico,
                cancellationToken);

            //ninnos urgentes
            var jovenes = await this.repository.GetAll<Joven>(
                x => x.Prioridad > 4,
                x => x.Prioridad,
                cancellationToken);

            foreach (var joven in jovenes)
            {
                if (joven.Prioridad > jovenComparacion.Prioridad)
                {
                    jovenMayores.Add(joven);
                }
            }

            return this.autoMapping.Map<List<Joven>, List<YourngUrgentListDTO>>(jovenMayores);
        }
    }
}
