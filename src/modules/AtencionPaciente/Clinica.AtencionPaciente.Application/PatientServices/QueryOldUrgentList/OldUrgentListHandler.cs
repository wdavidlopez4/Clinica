using Clinica.AtencionPaciente.Domain.Entities;
using Clinica.AtencionPaciente.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Application.PatientServices.QueryOldUrgentList
{
    public class OldUrgentListHandler : IRequestHandler<OldUrgentList, List<OldUrgentListDTO>>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public OldUrgentListHandler(IRepository repository, IAutoMapping autoMapping)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
        }

        public async Task<List<OldUrgentListDTO>> Handle(OldUrgentList request, CancellationToken cancellationToken)
        {
            var ancianoMayores = new List<Anciano>();

            //obtener joveb para comparacion
            var ancianoComparacion = await this.repository.Get<Anciano>(
                x => x.NumeroHistoriasClinico == request.NumeroHistoriasClinico,
                cancellationToken);

            //ninnos urgentes
            var ancianos = await this.repository.GetAll<Anciano>(
                x => x.Prioridad > 4,
                x => x.Prioridad,
                cancellationToken);

            foreach (var anciano in ancianos)
            {
                if (anciano.Prioridad > ancianoComparacion.Prioridad)
                {
                    ancianoMayores.Add(anciano);
                }
            }

            return this.autoMapping.Map<List<Anciano>, List<OldUrgentListDTO>>(ancianoMayores);
        }
    }
}
